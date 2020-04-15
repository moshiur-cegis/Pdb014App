// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../core/tsSupport/declareExtendsHelper ../../../../../core/tsSupport/decorateHelper ../../../../../core/HandleOwner ../../../../../core/accessorSupport/decorators".split(" "),function(c,e,f,d,g,b){Object.defineProperty(e,"__esModule",{value:!0});c=function(c){function a(a){a=c.call(this,a)||this;a.tiles=new Map;return a}f(a,c);a.prototype.destroy=function(){this.tiles.clear();this.layer=this.layerView=this.tileInfoView=this.tiles=null};Object.defineProperty(a.prototype,
"updating",{get:function(){return this.isUpdating()},enumerable:!0,configurable:!0});a.prototype.acquireTile=function(a){var h=this,b=this.createTile(a);b.once("isReady",function(){return h.notifyChange("updating")});this.tiles.set(a.id,b);return b};a.prototype.lockAttributeTextureUpload=function(){};a.prototype.unlockAttributeTextureUpload=function(){};a.prototype.forceAttributeTextureUpload=function(){};a.prototype.forEachTile=function(a){this.tiles.forEach(a)};a.prototype.releaseTile=function(a){this.tiles.delete(a.key.id);
this.disposeTile(a)};a.prototype.isUpdating=function(){var a=!0;this.tiles.forEach(function(b){a=a&&b.isReady});return!a};a.prototype.setHighlight=function(){};a.prototype.invalidateLabels=function(){};a.prototype.requestUpdate=function(){this.layerView.requestUpdate()};d([b.property()],a.prototype,"layer",void 0);d([b.property()],a.prototype,"layerView",void 0);d([b.property()],a.prototype,"tileInfoView",void 0);d([b.property()],a.prototype,"updating",null);return a=d([b.subclass("esri.views.2d.layers.features.tileRenderers.BaseTileRenderer")],
a)}(b.declared(g.HandleOwner));e.default=c});