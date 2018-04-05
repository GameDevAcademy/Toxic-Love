Shader "Unlit/Freeze" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Tint", Color) = (1, 1, 1, 1)
		_OutlineColor("Outline color", Color) = (1, 1, 1, 1)
		_OutlineWidth("Outline width", Range(0, 2)) = 0
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
				float _OutlineWidth;
				float4 _OutlineColor;

				fixed4 frag(v2f i) : COLOR
				{
					half4 c = tex2D(_MainTex, i.uv);
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