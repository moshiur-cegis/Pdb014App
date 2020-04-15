// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/extendsHelper ../../../../core/tsSupport/generatorHelper ../../../../core/tsSupport/awaiterHelper ../../../../Color ../../../../core/maybe ../../../../core/screenUtils ./ElevationAligners ./Graphics3DObject3DGraphicLayer ./Graphics3DSymbolCommonCode ./Graphics3DSymbolLayer ./graphicUtils ./symbolComplexity ../../webgl-engine/lib/Geometry ../../webgl-engine/lib/GeometryData ../../webgl-engine/lib/Util ../../webgl-engine/materials/LineCalloutMaterial".split(" "),
function(p,q,v,w,x,r,k,t,y,z,h,A,B,C,D,u,E,m){Object.defineProperty(q,"__esModule",{value:!0});var d,l,f=E.VertexAttrConstants;p=function(d){function b(a,c){a=d.call(this,a,null,c,!0)||this;a._elevationOptions={supportsOffsetAdjustment:!0,supportsOnTheGround:!1};return a}v(b,d);b.prototype.doLoad=function(){return x(this,void 0,void 0,function(){return w(this,function(a){this._material=new m(this.materialParameters,this._getIdHint("_lineCallout_common"));this._context.stage.add(3,this._material);
return[2]})})};b.prototype.destroy=function(){d.prototype.destroy.call(this);this._material&&(this._context.stage.remove(3,this._material.id),this._material=null)};b.prototype.perInstanceMaterialParameters=function(a){var c=this.materialParameters;c.screenOffset=a.screenOffset||[0,0];c.centerOffsetUnits=a.centerOffsetUnits||"world";return c};Object.defineProperty(b.prototype,"materialParameters",{get:function(){var a=this.symbol,c=a.callout,g=k.isSome(c.color)?r.toUnitRGBA(c.color):[0,0,0,0];g[3]*=
this._getLayerOpacity();var F=t.pt2px(c.size||0),e=null;if(a.verticalOffset)var e=a.verticalOffset,b=e.minWorldLength,d=e.maxWorldLength,e={screenLength:t.pt2px(e.screenLength),minWorldLength:b||0,maxWorldLength:null!=d?d:Infinity};c=k.isSome(c.border)&&k.isSome(c.border.color)?r.toUnitRGBA(c.border.color):null;b="object"===a.symbolLayers.getItemAt(0).type;return{color:g,size:F,verticalOffset:e,screenSizePerspective:this._context.screenSizePerspectiveEnabled?this._context.sharedResources.screenSizePerspectiveSettings:
null,screenOffset:[0,0],centerOffsetUnits:"world",borderColor:c,occlusionTest:!b,shaderPolygonOffset:b?0:void 0,depthHUDAlignStart:"label-3d"===a.type,slicePlaneEnabled:this._context.slicePlaneEnabled}},enumerable:!0,configurable:!0});b.prototype._defaultElevationInfoNoZ=function(){return G};b.prototype.createGraphics3DGraphic=function(a){var c=a.renderingInfo;a=a.graphic;var g=this.getGraphicElevationContext(a,c.elevationOffset||0),b=c.symbol,e="on-the-ground"===this._elevationContext.mode&&("cim"===
b.type||!b.symbolLayers.some(function(a){return"object"===a.type||"text"===a.type}));if("label-3d"!==b.type&&e)return null;b=B.computeCentroid(a.geometry);return k.isNone(b)?null:this._createAs3DShape(b,g,c,"graphic"+a.uid,a.uid)};b.prototype.layerOpacityChanged=function(){this._material.setParameterValues(this.materialParameters);return!0};b.prototype.layerElevationInfoChanged=function(a,c,g){var d=this;g=h.elevationModeChangeUpdateType(b.elevationModeChangeTypes,g,this._elevationContext.mode);if(g!==
h.SymbolUpdateType.UPDATE)return g;a.forEach(function(a){var b=c(a);k.isSome(b)&&d.updateGraphicElevationContext(a.graphic,b)});return g};b.prototype.slicePlaneEnabledChanged=function(){this._material.setParameterValues({slicePlaneEnabled:this._context.slicePlaneEnabled});return!0};b.prototype.physicalBasedRenderingChanged=function(){return!0};b.prototype.pixelRatioChanged=function(){return!0};b.prototype.getGraphicElevationContext=function(a,c){void 0===c&&(c=0);a=d.prototype.getGraphicElevationContext.call(this,
a);a.addOffsetRenderUnits(c);return a};b.prototype.updateGraphicElevationContext=function(a,c){a=this.getGraphicElevationContext(a,c.metadata.elevationOffset);c.elevationContext.set(a);c.needsElevationUpdates=h.needsElevationUpdates2D(a.mode)};b.prototype.computeComplexity=function(){return{primitivesPerFeature:2,primitivesPerCoordinate:0,estimated:!1,memory:C.emptySymbolComplexity.memory}};b.prototype.createVertexData=function(a){var c,b=a.translation;a=a.centerOffset;if(!b&&!a)return n;b=b?{size:3,
data:[b[0],b[1],b[2]]}:n[f.POSITION];a=a?{size:4,data:[a[0],a[1],a[2],a[3]]}:n[f.AUXPOS1];return c={},c[f.POSITION]=b,c[f.NORMAL]=n[f.NORMAL],c[f.AUXPOS1]=a,c};b.prototype.getOrCreateMaterial=function(a,b){var c=this.perInstanceMaterialParameters(a),d=m.uniqueMaterialIdentifier(c);if(d===this._material.uniqueMaterialIdentifier)return{material:this._material,isUnique:!1};if(a.materialCollection){var e=a.materialCollection.getMaterial(d);e||(e=new m(c,b+"_lineCallout_shared"),a.materialCollection.addMaterial(d,
e));return{material:e,isUnique:!1}}e=new m(c,b+"_lineCallout_unique");return{material:e,isUnique:!0}};b.prototype._createAs3DShape=function(a,b,d,f,e){var c=new u.GeometryData(this.createVertexData(d),H,u.GeometryData.DefaultOffsets,"point"),c=[new D(c,f)],g=this.getOrCreateMaterial(d,f);f=h.createStageObjectForPoint(this._context,a,c,[g.material],null,null,b,f,this._context.layer.uid,e,!0);if(null===f)return null;e=new z(this,f.object,c,g.isUnique?[g.material]:null,null,y.perObjectElevationAligner,
b);e.metadata={elevationOffset:d.elevationOffset||0};e.alignedTerrainElevation=f.terrainElevation;e.needsElevationUpdates=h.needsElevationUpdates2D(b.mode);h.extendPointGraphicElevationContext(e,a,this._context.elevationProvider);return e};b.elevationModeChangeTypes={definedChanged:h.SymbolUpdateType.UPDATE,staysOnTheGround:h.SymbolUpdateType.UPDATE,onTheGroundChanged:h.SymbolUpdateType.RECREATE};return b}(A.Graphics3DSymbolLayer);q.Graphics3DLineCalloutSymbolLayer=p;var n=(d={},d[f.POSITION]={size:3,
data:[0,0,0]},d[f.NORMAL]={size:3,data:[0,0,1]},d[f.AUXPOS1]={size:4,data:[0,0,0,1]},d);d=new Uint32Array([0]);var H=(l={},l[f.POSITION]=d,l[f.NORMAL]=d,l[f.AUXPOS1]=d,l),G={mode:"relative-to-ground",offset:0};q.default=p});