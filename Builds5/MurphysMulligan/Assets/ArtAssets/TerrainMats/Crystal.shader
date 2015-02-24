// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:0,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:2,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32602,y:32595|diff-53-RGB,spec-73-RGB,emission-93-OUT,amdfl-55-RGB,alpha-54-R,olwid-87-OUT,olcol-59-RGB;n:type:ShaderForge.SFN_Color,id:53,x:32801,y:32408,ptlb:Diffuse,ptin:_Diffuse,glob:False,c1:0.2268497,c2:0.1466263,c3:0.8308824,c4:1;n:type:ShaderForge.SFN_Color,id:54,x:33121,y:32951,ptlb:Alpha,ptin:_Alpha,glob:False,c1:0.5441177,c2:0.5441177,c3:0.5441177,c4:1;n:type:ShaderForge.SFN_Color,id:55,x:33293,y:32923,ptlb:Ambient Light,ptin:_AmbientLight,glob:False,c1:0.7941176,c2:0.3853806,c3:0.3853806,c4:1;n:type:ShaderForge.SFN_Color,id:59,x:33032,y:33183,ptlb:Outline Color,ptin:_OutlineColor,glob:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:60,x:33042,y:32672,ptlb:Emissive Tex,ptin:_EmissiveTex,tex:83d5358ada38994429f83f43198c16ac,ntxv:0,isnm:False|UVIN-62-UVOUT;n:type:ShaderForge.SFN_Panner,id:62,x:33218,y:32666,spu:1,spv:1|DIST-63-OUT;n:type:ShaderForge.SFN_Multiply,id:63,x:33533,y:32669|A-64-T,B-78-OUT;n:type:ShaderForge.SFN_Time,id:64,x:33765,y:32642;n:type:ShaderForge.SFN_Color,id:73,x:32901,y:32315,ptlb:Specular,ptin:_Specular,glob:False,c1:0.6602434,c2:0.6323529,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:78,x:33780,y:32863,ptlb:Emissive Speed,ptin:_EmissiveSpeed,glob:False,v1:0.015;n:type:ShaderForge.SFN_ValueProperty,id:87,x:33563,y:33059,ptlb:Outline Width,ptin:_OutlineWidth,glob:False,v1:0.02;n:type:ShaderForge.SFN_Multiply,id:93,x:32857,y:32728|A-100-OUT,B-95-OUT;n:type:ShaderForge.SFN_ValueProperty,id:95,x:33017,y:32878,ptlb:Emissive Strength,ptin:_EmissiveStrength,glob:False,v1:0;n:type:ShaderForge.SFN_Blend,id:100,x:32885,y:32538,blmd:10,clmp:True|SRC-101-RGB,DST-60-RGB;n:type:ShaderForge.SFN_Color,id:101,x:33123,y:32502,ptlb:Emissive Color,ptin:_EmissiveColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:53-73-60-101-95-78-55-54-59-87;pass:END;sub:END;*/

Shader "Shader Forge/Crystal" {
    Properties {
        _Diffuse ("Diffuse", Color) = (0.2268497,0.1466263,0.8308824,1)
        _Specular ("Specular", Color) = (0.6602434,0.6323529,1,1)
        _EmissiveTex ("Emissive Tex", 2D) = "white" {}
        _EmissiveColor ("Emissive Color", Color) = (0.5,0.5,0.5,1)
        _EmissiveStrength ("Emissive Strength", Float ) = 0
        _EmissiveSpeed ("Emissive Speed", Float ) = 0.015
        _AmbientLight ("Ambient Light", Color) = (0.7941176,0.3853806,0.3853806,1)
        _Alpha ("Alpha", Color) = (0.5441177,0.5441177,0.5441177,1)
        _OutlineColor ("Outline Color", Color) = (1,0,0,1)
        _OutlineWidth ("Outline Width", Float ) = 0.02
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _OutlineColor;
            uniform float _OutlineWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*_OutlineWidth,1));
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Diffuse;
            uniform float4 _Alpha;
            uniform float4 _AmbientLight;
            uniform sampler2D _EmissiveTex; uniform float4 _EmissiveTex_ST;
            uniform float4 _Specular;
            uniform float _EmissiveSpeed;
            uniform float _EmissiveStrength;
            uniform float4 _EmissiveColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb*2;
////// Emissive:
                float4 node_64 = _Time + _TimeEditor;
                float2 node_62 = (i.uv0.rg+(node_64.g*_EmissiveSpeed)*float2(1,1));
                float3 emissive = (saturate(( tex2D(_EmissiveTex,TRANSFORM_TEX(node_62, _EmissiveTex)).rgb > 0.5 ? (1.0-(1.0-2.0*(tex2D(_EmissiveTex,TRANSFORM_TEX(node_62, _EmissiveTex)).rgb-0.5))*(1.0-_EmissiveColor.rgb)) : (2.0*tex2D(_EmissiveTex,TRANSFORM_TEX(node_62, _EmissiveTex)).rgb*_EmissiveColor.rgb) ))*_EmissiveStrength);
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = _Specular.rgb;
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight += _AmbientLight.rgb; // Diffuse Ambient Light
                finalColor += diffuseLight * _Diffuse.rgb;
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,_Alpha.r);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
