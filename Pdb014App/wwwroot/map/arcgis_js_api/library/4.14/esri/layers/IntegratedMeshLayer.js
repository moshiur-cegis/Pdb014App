// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../core/tsSupport/assignHelper ../core/tsSupport/declareExtendsHelper ../core/tsSupport/decorateHelper ../core/tsSupport/generatorHelper ../core/tsSupport/awaiterHelper ../core/Error ../core/maybe ../core/MultiOriginJSONSupport ../core/accessorSupport/decorators ./Layer ./mixins/ArcGISService ./mixins/OperationalLayer ./mixins/PortalLayer ./mixins/ScaleRangeLayer ./mixins/SceneService ./support/commonProperties ./support/I3SLayerDefinitions".split(" "),function(w,x,h,k,d,y,
z,f,l,m,c,n,p,q,r,t,u,v,e){return function(g){function b(a,b){a=g.call(this,a)||this;a.geometryType="mesh";a.operationalLayerType="IntegratedMeshLayer";a.type="integrated-mesh";a.nodePages=null;a.materialDefinitions=null;a.textureSetDefinitions=null;a.geometryDefinitions=null;a.serviceUpdateTimeStamp=null;a.profile="mesh-pyramids";a.elevationInfo=null;a.path=null;return a}k(b,g);b.prototype.normalizeCtorArgs=function(a,b){return"string"===typeof a?h({url:a},b):a};b.prototype.load=function(a){var b=
this,c=l.isSome(a)?a.signal:null;a=this.loadFromPortal({supportedTypes:["Scene Service"]},a).then(function(){return b._fetchService(c)},function(){return b._fetchService(c)}).then(function(){return b._verifyRootNodeAndUpdateExtent(b.nodePages,c)});this.addResolvingPromise(a);return this.when()};b.prototype.validateLayer=function(a){if(a.layerType&&"IntegratedMesh"!==a.layerType)throw new f("integrated-mesh-layer:layer-type-not-supported","IntegratedMeshLayer does not support this layer type",{layerType:a.layerType});
if(isNaN(this.version.major)||isNaN(this.version.minor))throw new f("layer:service-version-not-supported","Service version is not supported.",{serviceVersion:this.version.versionString,supportedVersions:"1.x"});if(1<this.version.major)throw new f("layer:service-version-too-new","Service version is too new.",{serviceVersion:this.version.versionString,supportedVersions:"1.x"});};d([c.property({type:String,readOnly:!0})],b.prototype,"geometryType",void 0);d([c.property({type:["show","hide"]})],b.prototype,
"listMode",void 0);d([c.property({type:["IntegratedMeshLayer"]})],b.prototype,"operationalLayerType",void 0);d([c.property({json:{read:!1},readOnly:!0})],b.prototype,"type",void 0);d([c.property({type:e.I3SNodePageDefinition,readOnly:!0})],b.prototype,"nodePages",void 0);d([c.property({type:[e.I3SMaterialDefinition],readOnly:!0})],b.prototype,"materialDefinitions",void 0);d([c.property({type:[e.I3STextureSetDefinition],readOnly:!0})],b.prototype,"textureSetDefinitions",void 0);d([c.property({type:[e.I3SGeometryDefinition],
readOnly:!0})],b.prototype,"geometryDefinitions",void 0);d([c.property({readOnly:!0})],b.prototype,"serviceUpdateTimeStamp",void 0);d([c.property(v.elevationInfo)],b.prototype,"elevationInfo",void 0);d([c.property({type:String,json:{origins:{"web-scene":{read:!0,write:!0}},read:!1}})],b.prototype,"path",void 0);return b=d([c.subclass("esri.layers.IntegratedMeshLayer")],b)}(c.declared(t.ScaleRangeLayer(u.SceneService(p.ArcGISService(q.OperationalLayer(r.PortalLayer(m.MultiOriginJSONMixin(n))))))))});