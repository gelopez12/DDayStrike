Shader "Custom/OutlineShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (.5, .5, .5, 1)
        _Outline ("Outline width", Range (.002, 0.03)) = 0.005
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    SubShader
    {
        Tags {"Queue" = "Overlay" }

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }

    SubShader
    {
        Tags {"Queue" = "Overlay" }

        Pass
        {
            Cull Front

            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            uniform float _Outline;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                // Calculate distance to the nearest edge
                half2 d = fwidth(i.pos.xy);
                half alpha = saturate((d.x + d.y) * _Outline);

                // Mix the outline color with the original color
                half4 col = tex2D(_MainTex, i.pos.xy);
                col.rgb = lerp(col.rgb, _Color.rgb, alpha);

                return col;
            }
            ENDCG
        }
    }

    Fallback "Diffuse"
}