// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:2,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-189-OUT,spec-8-RGB,normal-14-RGB,emission-78-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33279,y:32488,ptlb:diffuse,ptin:_diffuse,tex:f936d042b5c53f146acf1c8d1db144f7,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8,x:33335,y:32652,ptlb:specular,ptin:_specular,tex:b23448a64d7e1244db6da59b468982ef,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:14,x:33427,y:32860,ptlb:normal,ptin:_normal,tex:b385cfc00d37fbb41bf743ea260068ae,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:20,x:33221,y:32967,ptlb:emissive,ptin:_emissive,tex:587fb778c64cbf24a9bf14edd4838732,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:51,x:33563,y:33130,uv:0;n:type:ShaderForge.SFN_Panner,id:52,x:33341,y:33193,spu:1,spv:1|UVIN-51-UVOUT,DIST-55-OUT;n:type:ShaderForge.SFN_Time,id:53,x:33718,y:33287;n:type:ShaderForge.SFN_Slider,id:54,x:33590,y:33462,ptlb:emissive overlay speed,ptin:_emissiveoverlayspeed,min:0,cur:0.7203192,max:10;n:type:ShaderForge.SFN_Multiply,id:55,x:33533,y:33287|A-53-T,B-54-OUT;n:type:ShaderForge.SFN_Tex2d,id:67,x:33191,y:33286,ptlb:emissive overlay,ptin:_emissiveoverlay,tex:de859d9470c21c34f830bbb4cfbc32cf,ntxv:0,isnm:False|UVIN-52-UVOUT;n:type:ShaderForge.SFN_Blend,id:78,x:33019,y:33102,blmd:0,clmp:True|SRC-67-RGB,DST-20-RGB;n:type:ShaderForge.SFN_Multiply,id:189,x:32886,y:32370|A-190-OUT,B-2-RGB;n:type:ShaderForge.SFN_Slider,id:190,x:32985,y:32228,ptlb:diffuse strength,ptin:_diffusestrength,min:0,cur:1.854706,max:10;proporder:2-190-14-8-20-67-54;pass:END;sub:END;*/

Shader "Shader Forge/Ball1" {
    Properties {
        _diffuse ("diffuse", 2D) = "black" {}
        _diffusestrength ("diffuse strength", Range(0, 10)) = 1.854706
        _normal ("normal", 2D) = "bump" {}
        _specular ("specular", 2D) = "white" {}
        _emissive ("emissive", 2D) = "white" {}
        _emissiveoverlay ("emissive overlay", 2D) = "white" {}
        _emissiveoverlayspeed ("emissive overlay speed", Range(0, 10)) = 0.7203192
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform sampler2D _emissive; uniform float4 _emissive_ST;
            uniform float _emissiveoverlayspeed;
            uniform sampler2D _emissiveoverlay; uniform float4 _emissiveoverlay_ST;
            uniform float _diffusestrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_199 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(node_199.rg, _normal))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
////// Emissive:
                float4 node_53 = _Time + _TimeEditor;
                float2 node_52 = (i.uv0.rg+(node_53.g*_emissiveoverlayspeed)*float2(1,1));
                float4 node_67 = tex2D(_emissiveoverlay,TRANSFORM_TEX(node_52, _emissiveoverlay));
                float4 node_20 = tex2D(_emissive,TRANSFORM_TEX(node_199.rg, _emissive));
                float3 emissive = saturate(min(node_67.rgb,node_20.rgb));
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = tex2D(_specular,TRANSFORM_TEX(node_199.rg, _specular)).rgb;
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_2 = tex2D(_diffuse,TRANSFORM_TEX(node_199.rg, _diffuse));
                finalColor += diffuseLight * (_diffusestrength*node_2.rgb);
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
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform sampler2D _emissive; uniform float4 _emissive_ST;
            uniform float _emissiveoverlayspeed;
            uniform sampler2D _emissiveoverlay; uniform float4 _emissiveoverlay_ST;
            uniform float _diffusestrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_200 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(node_200.rg, _normal))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
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
                float3 specularColor = tex2D(_specular,TRANSFORM_TEX(node_200.rg, _specular)).rgb;
                float3 specular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float4 node_2 = tex2D(_diffuse,TRANSFORM_TEX(node_200.rg, _diffuse));
                finalColor += diffuseLight * (_diffusestrength*node_2.rgb);
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
