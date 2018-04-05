Shader "Unlit/Freeze" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Tint", Color) = (1, 1, 1, 1)
		_OutlineColor("Outline color", Color) = (1, 1, 1, 1)
		_OutlineWidth("Outline width", Range(0, 2)) = 0

		_FreezeTex("Detail freeze", 2d) = "white" {}
		_Amount("Amount of detail", Range(0, 100)) = 100
		_Tile("Tiling", float) = 12
	}
	SubShader{
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
			Cull Off
			Blend One OneMinusSrcAlpha

			Pass{

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				sampler2D _MainTex;

				sampler2D _FreezeTex;
				float4 _FreezeTex_ST;

				struct v2f {
					float4 pos : SV_POSITION;
					half2 uv : TEXCOORD0;
				};

				v2f vert(appdata_base v) 
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = v.texcoord;
					return o;
				}

				fixed4 _Color;
				float4 _MainTex_TexelSize;
				float4 _OutlineColor;
				float _OutlineWidth;
				float _Amount;
				float _Tile;

				fixed4 frag(v2f i) : COLOR
				{
					half4 c = tex2D(_MainTex, i.uv);

					_FreezeTex_ST.xy = 10;

					half4 c1 = tex2D(_FreezeTex, float2(frac(i.uv.x * _Tile), frac(i.uv.y * _Tile)));

					c = lerp(c, float4(c1.r,c1.g,c1.g,c.a), _Amount / 100);
					c.rgb *= c.a;

					half4 outlineC = _OutlineColor;

					outlineC.a *= ceil(c.a);
					outlineC.rgb *= outlineC.a;

					if (_OutlineWidth == 0)
						return c;
					else
					{
						fixed alpha_up = tex2D(_MainTex, i.uv + fixed2(0, _MainTex_TexelSize.y * _OutlineWidth)).a;
						fixed alpha_down = tex2D(_MainTex, i.uv - fixed2(0, _MainTex_TexelSize.y * _OutlineWidth)).a;
						fixed alpha_right = tex2D(_MainTex, i.uv + fixed2(_MainTex_TexelSize.x * _OutlineWidth, 0)).a;
						fixed alpha_left = tex2D(_MainTex, i.uv - fixed2(_MainTex_TexelSize.x * _OutlineWidth, 0)).a;

						return lerp(outlineC, c, alpha_up * alpha_down * alpha_right * alpha_left) * _Color;
					}
				}

					ENDCG
			}
		}
		FallBack "Diffuse"
}