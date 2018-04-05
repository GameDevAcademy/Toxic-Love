Shader "Unlit/parallax"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Speed("Speed", float) = 1
		_Importance("Importance", Range(0, 100)) = 100
		_Direction("Direction", Range(1,-1)) = 1
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		Cull Off
		Blend One OneMinusSrcAlpha

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
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Importance;
			float _Direction;
			float _Speed;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{

				_Importance = 100 - _Importance;
				float2 pos = i.uv;
					if (_Speed > 0)
						pos = i.uv + float2(_Time.x * _Speed * _Direction, 0);

				fixed4 col = tex2D(_MainTex, pos);
				col.rgb *= col.a;

				return  lerp(col, float4(0, 0, 0, col.a), _Importance / 100);
			}
			ENDCG
		}
	}
}
