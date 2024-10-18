Shader "Custom/LavaShader"
{
    Properties
    {
        _MainTex ("Lava Texture", 2D) = "white" {} // Lava texture
        _NoiseTex ("Noise Texture", 2D) = "white" {} // Noise for distortion
        _LavaColor ("Lava Color", Color) = (1, 0.5, 0, 1) // Color of the lava
        _EmissionColor ("Emission Color", Color) = (1, 0.3, 0, 1) // Glow color
        _FlowSpeed ("Flow Speed", Range(0.0, 5.0)) = 1.0 // Speed of flow animation
        _DistortAmount ("Distortion Amount", Range(0.0, 1.0)) = 0.5 // Distortion level
        _EmissionStrength ("Emission Strength", Range(0.0, 5.0)) = 2.0 // Strength of the glow
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
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
                float4 pos : SV_POSITION;
            };

            // Properties
            sampler2D _MainTex;
            sampler2D _NoiseTex;
            float4 _LavaColor;
            float4 _EmissionColor;
            float _FlowSpeed;
            float _DistortAmount;
            float _EmissionStrength;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Animate texture UV coordinates for flowing effect
                float2 flowUV = i.uv + _FlowSpeed * _Time.y * float2(1.0, 0.5);
                
                // Sample the main lava texture
                fixed4 lavaTex = tex2D(_MainTex, flowUV);
                
                // Add noise-based distortion for a more dynamic look
                float2 noiseUV = i.uv * 2.0 + _Time.y * _FlowSpeed;
                fixed4 noiseTex = tex2D(_NoiseTex, noiseUV);
                float2 distortedUV = i.uv + (noiseTex.xy - 0.5) * _DistortAmount;
                fixed4 distortedLava = tex2D(_MainTex, distortedUV);
                
                // Apply the lava color to the distorted texture
                fixed4 finalColor = lerp(lavaTex, distortedLava, 0.5) * _LavaColor;

                // Add emissive glow effect
                fixed4 emissive = _EmissionColor * _EmissionStrength * (lavaTex.r);

                // Return final color with emissive glow
                return finalColor + emissive;
            }
            ENDCG
        }
    }

    // Fallback for low-end hardware
    Fallback "Diffuse"
}
