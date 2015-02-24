// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.9701493,fgcg:0.9701493,fgcb:0.9701493,fgca:1,fgde:0.0004,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-2-RGB,spec-62-OUT,emission-6-OUT,olwid-39-OUT,olcol-45-RGB;n:type:ShaderForge.SFN_Color,id:2,x:33050,y:32361,ptlb:Diffuse,ptin:_Diffuse,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:3,x:33565,y:32397,ptlb:Specular ,ptin:_Specular,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4,x:33156,y:32836,ptlb:Emissive ,ptin:_Emissive,ntxv:0,isnm:False|UVIN-12-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6,x:32964,y:32846|A-55-OUT,B-16-OUT;n:type:ShaderForge.SFN_Panner,id:12,x:33303,y:32911,spu:1,spv:1|DIST-13-OUT;n:type:ShaderForge.SFN_Multiply,id:13,x:33472,y:33077|A-23-T,B-22-OUT;n:type:ShaderForge.SFN_ValueProperty,id:16,x:33156,y:33033,ptlb:Emissive Strength,ptin:_EmissiveStrength,glob:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:22,x:33759,y:33146,ptlb:Emissive Speed,ptin:_EmissiveSpeed,glob:False,v1:0;n:type:ShaderForge.SFN_Time,id:23,x:33680,y:32957;n:type:ShaderForge.SFN_ValueProperty,id:39,x:33003,y:33008,ptlb:Outline Width,ptin:_OutlineWidth,glob:False,v1:0;n:type:ShaderForge.SFN_Color,id:45,x:32998,y:33122,ptlb:Outline Color,ptin:_OutlineColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:54,x:33200,y:32628,ptlb:Emissive Color,ptin:_EmissiveColor,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:55,x:33007,y:32688,blmd:10,clmp:True|SRC-54-RGB,DST-4-RGB;n:type:ShaderForge.SFN_Multiply,id:62,x:33462,y:32598|A-3-RGB,B-63-OUT;n:type:ShaderForge.SFN_ValueProperty,id:63,x:33680,y:32751,ptlb:Specular Strength,ptin:_SpecularStrength,glob:False,v1:0;proporder:2-3-63-54-4-16-22-39-45;pass:END;sub:END;*/

Shader "Shader Forge/Solid" {
    Properties {
        _Diffuse ("Diffuse", Color) = (0.5,0.5,0.5,1)
        _Specular ("Specular ", Color) = (0.5,0.5,0.5,1)
        _SpecularStrength ("Specular Strength", Float ) = 0
        _EmissiveColor ("Emissive Color", Color) = (0.5,0.5,0.5,1)
        _Emissive ("Emissive ", 2D) = "white" {}
        _EmissiveStrength ("Emissive Strength", Float ) = 0
        _EmissiveSpeed ("Emissive Speed", Float ) = 0
        _OutlineWidth ("Outline Width", Float ) = 0
        _OutlineColor ("Outline Color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform float _OutlineWidth;
            uniform float4 _OutlineColor;
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Diffuse;
            uniform float4 _Specular;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float _EmissiveStrength;
            uniform float _EmissiveSpeed;
            uniform float4 _EmissiveColor;
            uniform float _SpecularStrength;
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
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
////// Emissive:
                float4 node_23 = _Time + _TimeEditor;
                float2 node_12 = (i.uv0.rg+(node_23.g*_EmissiveSpeed)*float2(1,1));
                float3 emissive = (saturate(( tex2D(_Emissive,TRANSFORM_TEX(node_12, _Emissive)).rgb > 0.5 ? (1.0-(1.0-2.0*(tex2D(_Emissive,TRANSFORM_TEX(node_12, _Emissive)).rgb-0.5))*(1.0-_EmissiveColor.rgb)) : (2.0*tex2D(_Emissive,TRANSFORM_TEX(node_12, _Emissive)).rgb*_EmissiveColor.rgb) ))*_EmissiveStrength);
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (_Specular.rgb*_SpecularStrength);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * _Diffuse.rgb;
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Diffuse;
            uniform float4 _Specular;
            uniform sampler2D _Emissive; uniform float4 _Emissive_ST;
            uniform float _EmissiveStrength;
            uniform float _EmissiveSpeed;
            uniform float4 _EmissiveColor;
            uniform float _SpecularStrength;
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
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (_Specular.rgb*_SpecularStrength);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * _Diffuse.rgb;
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
