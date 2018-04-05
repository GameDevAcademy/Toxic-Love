Shader "ImageEffects/Acid"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Detail("Acid detail texture", 2d) = "white" {}
		_Amount("Amount of acid", Range(0,1)) = 5
		_Size("Curling", float) = 45
		_Speed("Speed", float) = 2
	}
	SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				float _Amount;
				float _Speed;
				float _Size;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				sampler2D _Detail;

				fixed4 frag(v2f i) : SV_Target
				{
					float ct = (sin(_Time.x) + 1) / (_Size * 2);
					float2 pos = i.uv + float2(0, sin(i.vertex.x / _Size * _Time.x) * _Speed);

					fixed4 col = tex2D(_MainTex, pos);
					fixed4 col1 = tex2D(_Detail, pos);

					col = lerp(col, col1 + float4(0, 0.5 , 0, 0), _Amount);
					return col;
				}
				ENDCG
			}
		}
}
