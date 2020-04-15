// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/extendsHelper ../../../../core/tsSupport/generatorHelper ../../../../core/tsSupport/awaiterHelper ../../../../core/tsSupport/assignHelper ../../../../Color ../../../../core/compilerUtils ../../../../core/maybe ../../../../core/libs/gl-matrix-2/mat3 ../../../../core/libs/gl-matrix-2/mat3f64 ../../../../core/libs/gl-matrix-2/mat4 ../../../../core/libs/gl-matrix-2/mat4f64 ../../../../core/libs/gl-matrix-2/vec3 ../../../../core/libs/gl-matrix-2/vec3f64 ../../../../core/libs/gl-matrix-2/vec4f64 ../../../../geometry/support/aaBoundingBox ../../../../geometry/support/MeshComponent ../../../../geometry/support/webMercatorUtils ../../../../geometry/support/meshUtils/projection ./ElevationAligners ./Graphics3DObject3DGraphicLayer ./Graphics3DSymbolCommonCode ./Graphics3DSymbolLayer ../support/edgeUtils ../support/symbolColorUtils ../../support/debugFlags ../../support/projectionUtils ../../webgl-engine/lib/Geometry ../../webgl-engine/lib/GeometryData ../../webgl-engine/lib/Object3D ../../webgl-engine/lib/Texture ../../webgl-engine/lib/Util ../../webgl-engine/materials/DefaultMaterial ../../webgl-engine/materials/NativeLineMaterial ../../webgl-engine/materials/internal/MaterialUtil".split(" "),
function(u,I,W,X,Y,Z,J,aa,q,O,ba,ca,F,n,l,P,da,ea,fa,Q,ga,ha,r,ia,ja,R,S,ka,K,L,la,ma,na,oa,T,pa){Object.defineProperty(I,"__esModule",{value:!0});var h=na.VertexAttrConstants;u=function(u){function d(a,b,c,e){a=u.call(this,a,b,c,e)||this;a._materials=new Map;a._textures=new Map;return a}W(d,u);d.prototype.doLoad=function(){return Y(this,void 0,void 0,function(){return X(this,function(a){S.DRAW_MESH_GEOMETRY_NORMALS&&(this._debugVertexNormalMaterial=new T({color:[1,0,1,1]},"debugVertexNormal"),this._debugFaceNormalMaterial=
new T({color:[0,1,1,1]},"debugFAceNormal"));return[2]})})};d.prototype.destroy=function(){var a=this;u.prototype.destroy.call(this);this._materials.forEach(function(b){a._context.stage.remove(3,b.material.id)});this._textures.forEach(function(b){a._context.stage.remove(4,b.id)});this._materials.clear();this._textures.clear()};d.prototype.createGraphics3DGraphic=function(a){var b=a.graphic;if(!this._validateGeometryType(b.geometry,d.validGeometryTypes,"fill on mesh-3d")||!this._validateGeometry(b.geometry))return null;
var c="graphic"+b.uid,e=this.getGraphicElevationContext(b);return this._createAs3DShape(b,a.renderingInfo,e,c,b.uid)};d.prototype.layerOpacityChanged=function(a,b){var c=this,e=this._getLayerOpacity();this._materials.forEach(function(a){a.material.setParameterValues({layerOpacity:e});var b=a.material.getParameters();c._setMaterialTransparentParameter(b,a);a.material.setParameterValues({transparent:b.transparent})});a.forEach(function(a){a=b(a);q.isSome(a)&&a.layerOpacityChanged(e,c._context.isAsync)});
return!0};d.prototype.layerElevationInfoChanged=function(a,b){return this.updateGraphics3DGraphicElevationInfo(a,b,r.needsElevationUpdates3D)};d.prototype.slicePlaneEnabledChanged=function(a,b){var c=this;this._materials.forEach(function(a){a.material.setParameterValues({slicePlaneEnabled:c._context.slicePlaneEnabled})});a.forEach(function(a){a=b(a);q.isSome(a)&&a.slicePlaneEnabledChanged(c._context.slicePlaneEnabled,c._context.isAsync)});return!0};d.prototype.physicalBasedRenderingChanged=function(){var a=
this;this._materials.forEach(function(b){b.material.setParameterValues({usePBR:a._context.physicalBasedRenderingEnabled})});return!0};d.prototype.pixelRatioChanged=function(){return!0};d.prototype._requiresSymbolVertexColors=function(){return this._drivenProperties.color||this._drivenProperties.opacity};d.prototype._colorOrTextureUid=function(a){return a?a instanceof J?a.toHex():a.contentHash:"-"};d.prototype._materialProperties=function(a,b,c){var e=this._requiresSymbolVertexColors(),g,k,d,f,h,t,
n,l,w;b.material&&(k=b.material.color,g=this._colorOrTextureUid(b.material.color),d=b.material.colorTexture,f=this._colorOrTextureUid(b.material.colorTexture),h=b.material.normalTexture,t=this._colorOrTextureUid(b.material.normalTexture),n=b.material.doubleSided,l=b.material.alphaCutoff,w=b.material.alphaMode);b=!!a.vertexAttributes.color;a=!!a.vertexAttributes.tangent;return{hasSymbolVertexColors:e,hasVertexColors:b,hasVertexTangents:a,color:k,colorTexture:d,normalTexture:h,uid:"vc:"+b+",vt:"+a+
",vct"+c+",svc:"+e+",cmuid:"+g+",ctmuid:"+f+",ntmuid:"+t+",ds:"+n+",ac:"+l+",am:"+w}};d.prototype._setInternalColorValueParameters=function(a,b){b.diffuse=J.toUnitRGB(a);b.opacity=a.a};d.prototype._getLoadableTextureResource=function(a){return a.data?a.data instanceof HTMLImageElement?a.data.complete?a.data:a.data.src:a.data:a.url};d.prototype._getInternalTextureId=function(a,b){var c=this._getLoadableTextureResource(a);if(c){var e=a.contentHash,g=this._textures.get(e);g||(g=new ma(c,b+"_"+e+"_tex",
{mipmap:!0,wrap:this._castTextureWrap(a.wrap),noUnpackFlip:!0}),this._textures.set(e,g),this._context.stage.add(4,g));return g.id}};d.prototype._castTextureWrap=function(a){void 0===a&&(a="repeat");return"string"===typeof a?(a=this._castTextureWrapIndividual(a),{s:a,t:a}):{s:this._castTextureWrapIndividual(a.horizontal),t:this._castTextureWrapIndividual(a.vertical)}};d.prototype._castTextureWrapIndividual=function(a){switch(a){case "clamp":return 33071;case "mirror":return 33648;default:return 10497}};
d.prototype._setInternalMaterialParameters=function(a,b,c){a.color&&this._setInternalColorValueParameters(a.color,c);a.colorTexture&&(c.textureId=this._getInternalTextureId(a.colorTexture,b));a.normalTexture&&(c.normalTextureId=this._getInternalTextureId(a.normalTexture,b))};d.prototype._setExternalMaterialParameters=function(a){var b=this._drivenProperties.color,c=q.isSome(this.symbolLayer.material)?this.symbolLayer.material.colorMixMode:null;b?a.externalColor=P.vec4f64.ONES:(b=q.isSome(this.symbolLayer.material)?
this.symbolLayer.material.color:null,q.isSome(b)?a.externalColor=J.toUnitRGBA(b):(c=null,a.externalColor=P.vec4f64.ONES));c&&(a.colorMixMode=c)};d.prototype._hasTransparentVertexColors=function(a){a=a.vertexAttributes.color;if(!a)return!1;for(var b=3;b<a.length;b+=4)if(255!==a[b])return!0;return!1};d.prototype._getOrCreateMaterial=function(a,b){var c=b.material&&b.material.color,e=b.material&&b.material.colorTexture,g=b.material&&"blend"===b.material.alphaMode,c=!(b.material&&"opaque"===b.material.alphaMode)&&
(this._hasTransparentVertexColors(a)||c&&1>c.a||e&&e.transparent||g);a=this._materialProperties(a,b,c);if(e=this._materials.get(a.uid))return e.material;c={material:null,isComponentTransparent:c,alphaMode:b.material?b.material.alphaMode:"opaque"};e=this._getIdHint();g=Z({},pa.getDefaultPBRMaterialParameters(this._context.physicalBasedRenderingEnabled),{specular:l.vec3f64.ZEROS,vertexColors:a.hasVertexColors,symbolColors:a.hasSymbolVertexColors,vertexTangents:a.hasVertexTangents,ambient:l.vec3f64.ZEROS,
diffuse:l.vec3f64.ONES,opacity:1,doubleSided:!0,doubleSidedType:"winding-order",cullFace:0,layerOpacity:this._getLayerOpacity(),slicePlaneEnabled:this._context.slicePlaneEnabled,initTextureTransparent:!0});b.material&&(g.doubleSided=b.material.doubleSided,g.cullFace=b.material.doubleSided?0:2,g.textureAlphaCutoff=b.material.alphaCutoff);this._setInternalMaterialParameters(a,e,g);this._setExternalMaterialParameters(g);this._setMaterialTransparentParameter(g,c);b=new oa(g,e+"_"+a.uid+"_mat");c.material=
b;this._materials.set(a.uid,c);this._context.stage.add(3,b);return b};d.prototype._setMaterialTransparentParameter=function(a,b){a.transparent=this.needsDrivenTransparentPass||b.isComponentTransparent||1>a.layerOpacity||1>a.opacity||a.externalColor&&1>a.externalColor[3];a.textureAlphaMode="auto"===b.alphaMode?a.transparent?"maskBlend":"opaque":b.alphaMode};d.prototype._addDebugNormals=function(a,b,c,e){var g,k,d,M,l=b.length,t=a.spatialReference.isGeographic?20015077/180:1,u=.1*Math.max(a.extent.width*
t,a.extent.height*t,a.extent.zmax-a.extent.zmin),q=[],w=[];a=[];for(var t=[],r=0;r<l;r++)for(var z=b[r],x=z.data.getAttribute(h.POSITION),N=z.data.getAttribute(h.NORMAL),A=z.data.getIndices(h.POSITION),z=z.data.getIndices(h.NORMAL),x=x.data,N=N.data,m=0;m<A.length;m++){for(var v=3*A[m],D=3*z[m],p=0;3>p;p++)q.push(x[v+p]);for(p=0;3>p;p++)q.push(x[v+p]+N[D+p]*u);w.push(w.length);w.push(w.length);if(0===m%3){this._calculateFaceNormal(x,A,m,B);this._getFaceVertices(x,A,m,f,C,E);n.vec3.add(f,f,C);n.vec3.add(f,
f,E);n.vec3.scale(f,f,1/3);for(p=0;3>p;p++)a.push(f[p]);for(p=0;3>p;p++)a.push(f[p]+B[p]*u);t.push(t.length);t.push(t.length)}}l=(g={},g[h.POSITION]={data:new Float64Array(q),size:3},g);g=(k={},k[h.POSITION]=new Uint32Array(w),k);k=new L.GeometryData(l,g,void 0,"line");k=new K(k,"debugVertexNormal");k.singleUse=!0;b.push(k);c.push(this._debugVertexNormalMaterial);e.push(F.mat4f64.clone(e[0]));l=(d={},d[h.POSITION]={data:new Float64Array(a),size:3},d);g=(M={},M[h.POSITION]=new Uint32Array(t),M);k=
new L.GeometryData(l,g,void 0,"line");k=new K(k,"debugFaceNormal");k.singleUse=!0;b.push(k);c.push(this._debugFaceNormalMaterial);e.push(F.mat4f64.clone(e[0]))};d.prototype._createAs3DShape=function(a,b,c,e,g){a=a.geometry;if("mesh"!==a.type)return null;var k=this._createGeometryInfo(a,b,e);if(!k)return null;b=k.geometries;var d=k.materials,f=k.transformations,k=k.objectTransformation;S.DRAW_MESH_GEOMETRY_NORMALS&&this._addDebugNormals(a,b,d,f);g=new la({geometries:b,materials:d,transformations:f,
castShadow:!0,metadata:{layerUid:this._context.layer.uid,graphicUid:g},idHint:e});g.objectTransformation=k;e=ga.perObjectElevationAligner;f=this._createEdgeMaterial();d=q.isSome(f)?{baseMaterial:d[0],edgeMaterials:[f],addObjectSettings:{mergeGeometries:!0},slicePlaneEnabled:this._context.slicePlaneEnabled}:null;b=new ha(this,g,b,null,null,e,c,d);b.needsElevationUpdates=r.needsElevationUpdates3D(c.mode);c=a.extent.center.clone();c.z=0;b.elevationContext.centerPointInElevationSR=c;b.alignedTerrainElevation=
e(b,b.elevationContext,this._context.elevationProvider,this._context.renderCoordsHelper);return b};d.prototype._createComponentNormals=function(a,b,c,e){var g=c.shading||"flat";switch(g){case "source":return this._createComponentNormalsSource(a,b,c,e);case "flat":return this._createComponentNormalsFlat(a,e);case "smooth":return this._createComponentNormalsSmooth(a,e);default:aa.neverReached(g)}};d.prototype._createComponentNormalsSource=function(a,b,c,e){if(!b)return this._createComponentNormalsFlat(a,
e);var g=!1;if(!c.trustSourceNormals)for(c=0;c<e.length;c+=3){this._calculateFaceNormal(a,e,c,B);for(var d=0;3>d;d++){var y=3*e[c+d];f[0]=b[y+0];f[1]=b[y+1];f[2]=b[y+2];0>n.vec3.dot(B,f)&&(b[y+0]=-b[y+0],b[y+1]=-b[y+1],b[y+2]=-b[y+2],g=!0)}}return{normals:b,indices:e,didFlipNormals:g}};d.prototype._createComponentNormalsFlat=function(a,b){for(var c=new Float32Array(b.length),e=new Uint32Array(3*b.length),g=0;g<b.length;g+=3)for(var d=this._calculateFaceNormal(a,b,g,B),f=0;3>f;f++)c[g+f]=d[f],e[g+
f]=g/3;return{normals:c,indices:e,didFlipNormals:!1}};d.prototype._createComponentNormalsSmooth=function(a,b){for(var c={},e=0;e<b.length;e+=3)for(var g=this._calculateFaceNormal(a,b,e,B),d=0;3>d;d++){var f=b[e+d],h=c[f];h||(h={normal:l.vec3f64.create(),count:0},c[f]=h);n.vec3.add(h.normal,h.normal,g);h.count++}a=new Float32Array(3*b.length);g=new Uint32Array(3*b.length);for(e=0;e<b.length;e++){f=b[e];h=c[f];1!==h.count&&(n.vec3.normalize(h.normal,h.normal),h.count=1);for(d=0;3>d;d++)a[3*e+d]=h.normal[d];
g[e]=e}return{normals:a,indices:g,didFlipNormals:!1}};d.prototype._getFaceVertices=function(a,b,c,e,d,f){var g=3*b[c+0],k=3*b[c+1];b=3*b[c+2];e[0]=a[g+0];e[1]=a[g+1];e[2]=a[g+2];d[0]=a[k+0];d[1]=a[k+1];d[2]=a[k+2];f[0]=a[b+0];f[1]=a[b+1];f[2]=a[b+2]};d.prototype._calculateFaceNormal=function(a,b,c,e){this._getFaceVertices(a,b,c,f,C,E);n.vec3.subtract(C,C,f);n.vec3.subtract(E,E,f);n.vec3.cross(f,C,E);n.vec3.normalize(e,f);return e};d.prototype._getOrCreateComponents=function(a){return a.components?
a.components:qa};d.prototype._createPositionBuffer=function(a){var b=a.vertexAttributes.position,c=new Float64Array(b.length);r.reproject(a.vertexAttributes.position,0,a.spatialReference,c,0,this._context.renderSpatialReference,b.length/3);return c};d.prototype._createNormalBuffer=function(a,b){var c=a.vertexAttributes.normal;if(!c)return null;if("local"===this._context.layerView.view.viewingMode)return c;var e=a.vertexAttributes.position,d=new Float32Array(c.length);return Q.projectNormalToECEF(c,
e,b,a.spatialReference,d)};d.prototype._createTangentBuffer=function(a,b){var c=a.vertexAttributes.tangent;if(!c)return null;if("local"===this._context.layerView.view.viewingMode)return c;var e=a.vertexAttributes.position,d=new Float32Array(c.length);return Q.projectTangentToECEF(c,e,b,a.spatialReference,d)};d.prototype._createColorBuffer=function(a){return a.vertexAttributes.color};d.prototype._createSymbolColorBuffer=function(a){if(this._requiresSymbolVertexColors()){a=this._getVertexOpacityAndColor(a);
var b=R.parseColorMixMode(q.get(this.symbolLayer,"material","colorMixMode")),c=new Uint8Array(4);R.encodeSymbolColor(a,b,c);return c}return null};d.prototype._createColorIndices=function(a){a=new Uint32Array(a.length);for(var b=0;b<a.length;b++)a[b]=0;return a};d.prototype._createBuffers=function(a,b){var c=a.vertexAttributes&&a.vertexAttributes.position;if(!c)return this.logger.warn("Mesh geometry must contain position vertex attributes"),null;var e=a.vertexAttributes.normal,d=a.vertexAttributes.uv,
f=a.vertexAttributes.tangent;if(e&&e.length!==c.length)return this.logger.warn("Mesh normal vertex buffer must contain the same number of elements as the position buffer"),null;if(f&&f.length/4!==c.length/3)return this.logger.warn("Mesh tangent vertex buffer must contain the same number of elements as the position buffer"),null;if(d&&d.length/2!==c.length/3)return this.logger.warn("Mesh uv vertex buffer must contain the same number of elements as the position buffer"),null;c=this._createPositionBuffer(a);
e=this._createColorBuffer(a);b=this._createSymbolColorBuffer(b);var f=this._createNormalBuffer(a,c),h=this._createTangentBuffer(a,c);a=this._transformCenterLocal(a,c,f);return{positionBuffer:c,normalBuffer:f,tangentBuffer:h,uvBuffer:d,colorBuffer:e,symbolColorBuffer:b,objectTransformation:a}};d.prototype._transformCenterLocal=function(a,b,c){var e=a.extent.center,d=this._context.renderSpatialReference;G[0]=e.x;G[1]=e.y;G[2]=0;e=F.mat4f64.create();ka.computeLinearTransformation(a.spatialReference,
G,e,d);ca.mat4.invert(U,e);for(a=0;a<b.length;a+=3)f[0]=b[a+0],f[1]=b[a+1],f[2]=b[a+2],n.vec3.transformMat4(f,f,U),b[a+0]=f[0],b[a+1]=f[1],b[a+2]=f[2];if(c)for(O.mat3.fromMat4(H,e),O.mat3.transpose(H,H),a=0;a<c.length;a+=3)f[0]=c[a+0],f[1]=c[a+1],f[2]=c[a+2],n.vec3.transformMat3(f,f,H),c[a+0]=f[0],c[a+1]=f[1],c[a+2]=f[2];return e};d.prototype._validateFaces=function(a,b){a=a.vertexAttributes.position.length/3;if(b=b.faces){for(var c=-1,e=0;e<b.length;e++){var d=b[e];d>c&&(c=d)}if(a<=c)return this.logger.warn("Vertex index "+
c+" is out of bounds of the mesh position buffer"),!1}else if(0!==a%3)return this.logger.warn("Mesh position buffer length must be a multiple of 9 if no component faces are defined (3 values per vertex * 3 vertices per triangle)"),!1;return!0};d.prototype._getOrCreateFaces=function(a,b){if(b.faces)return b.faces;a=new Uint32Array(a.vertexAttributes.position.length/3);for(b=0;b<a.length;b++)a[b]=b;return a};d.prototype._isOutsideClippingArea=function(a){if(!this._context.clippingExtent)return!1;var b=
a.vertexAttributes&&a.vertexAttributes.position;if(!b)return!1;var c=this._context.elevationProvider.spatialReference,e=b.length/3;a.spatialReference.equals(c)||(b=new Float64Array(b.length),r.reproject(a.vertexAttributes.position,0,a.spatialReference,b,0,c,e));r.computeBoundingBox(b,0,e,V);return r.boundingBoxClipped(V,this._context.clippingExtent)};d.prototype._createGeometryInfo=function(a,b,c){var e,d;if(!fa.canProject(a,this._context.layerView.view.spatialReference))return this.logger.warn("Geometry spatial reference is not compatible with the view"),
null;if(this._isOutsideClippingArea(a))return null;var f=this._createBuffers(a,b);if(!f)return null;b=f.positionBuffer;for(var l=f.uvBuffer,n=f.colorBuffer,q=f.symbolColorBuffer,t=f.normalBuffer,u=f.tangentBuffer,f=f.objectTransformation,r=[],w=[],B=[],z=!1,x=0,C=this._getOrCreateComponents(a);x<C.length;x++){var A=C[x];if(!this._validateFaces(a,A))return null;var m=this._getOrCreateFaces(a,A);if(0!==m.length){var v=this._createComponentNormals(b,t,A,m);v.didFlipNormals&&(z=!0);var D=(e={},e[h.POSITION]=
{size:3,data:b},e[h.NORMAL]={size:3,data:v.normals},e),v=(d={},d[h.POSITION]=m,d[h.NORMAL]=v.indices,d);n&&(D[h.COLOR]={size:4,data:n},v[h.COLOR]=m);q&&(D[h.SYMBOLCOLOR]={size:4,data:q},v[h.SYMBOLCOLOR]=this._createColorIndices(m));a.vertexAttributes.uv&&(D[h.UV0]={size:2,data:l},v[h.UV0]=m);a.vertexAttributes.tangent&&(D[h.TANGENT]={size:4,data:u},v[h.TANGENT]=m);m=new L.GeometryData(D,v);m=new K(m,c+"_mesh");m.singleUse=!0;r.push(m);w.push(F.mat4f64.create());B.push(this._getOrCreateMaterial(a,
A))}}z&&this.logger.warn("Normals have been automatically flipped to be consistent with the counter clock wise face winding order. It is better to generate mesh geometries that have consistent normals.");return{geometries:r,transformations:w,materials:B,objectTransformation:f}};d.prototype._createEdgeMaterial=function(){var a={opacity:this._getLayerOpacity()};return ja.createMaterial(this.symbolLayer,a)};d.validGeometryTypes=["mesh"];return d}(ia.default);I.Graphics3DMeshFillSymbolLayer=u;var G=l.vec3f64.create(),
f=l.vec3f64.create(),C=l.vec3f64.create(),E=l.vec3f64.create(),B=l.vec3f64.create(),U=F.mat4f64.create(),H=ba.mat3f64.create(),V=da.create(),qa=[new ea];I.default=u});