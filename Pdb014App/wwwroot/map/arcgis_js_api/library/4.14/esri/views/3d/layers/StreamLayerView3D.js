// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/decorateHelper ../../../core/tsSupport/generatorHelper ../../../core/tsSupport/awaiterHelper ../../../Graphic ../../../core/Collection ../../../core/promiseUtils ../../../core/accessorSupport/decorators ../../../tasks/support/Query ./FeatureLikeLayerView3D ./LayerView3D ../../layers/LayerView ../../layers/StreamLayerView".split(" "),function(e,u,f,b,g,h,k,l,m,c,n,p,q,r,t){return function(d){function a(){return null!==
d&&d.apply(this,arguments)||this}f(a,d);a.prototype.createQuery=function(){return new n({outFields:["*"],returnGeometry:!0,outSpatialReference:this.view.spatialReference})};a.prototype.createController=function(){return h(this,void 0,void 0,function(){var a,c,b;return g(this,function(d){switch(d.label){case 0:return a=l.ofType(k),[4,m.create(function(a){e(["../../../layers/graphics/controllers/StreamController"],a)})];case 1:return c=d.sent(),b=new c({layer:this.layer,layerView:this,graphics:new a}),
[4,b.when()];case 2:return d.sent(),[2,b]}})})};b([c.property()],a.prototype,"controller",void 0);b([c.property({readOnly:!0,aliasOf:"layer.capabilities.data.supportsZ"})],a.prototype,"hasZ",void 0);b([c.property({readOnly:!0,aliasOf:"layer.capabilities.data.supportsM"})],a.prototype,"hasM",void 0);return a=b([c.subclass("esri.views.3d.layers.StreamLayerView3D")],a)}(c.declared(t.StreamLayerView(p.FeatureLikeLayerView3D(q.LayerView3D(r)))))});