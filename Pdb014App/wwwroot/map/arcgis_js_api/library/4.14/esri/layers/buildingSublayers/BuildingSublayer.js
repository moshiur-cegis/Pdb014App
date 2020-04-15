// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../core/tsSupport/assignHelper ../../core/tsSupport/declareExtendsHelper ../../core/tsSupport/decorateHelper ../../core/Identifiable ../../core/MultiOriginJSONSupport ../../core/accessorSupport/decorators ../support/commonProperties".split(" "),function(k,l,m,e,c,f,g,b,h){return function(d){function a(a){a=d.call(this,a)||this;a.title="";a.id=-1;a.modelName=null;a.visible=!0;a.opacity=1;return a}e(a,d);a.prototype.readTitle=function(a,b){return"string"===typeof b.alias?
b.alias:"string"===typeof b.name?b.name:""};a.prototype.readIdOnlyOnce=function(a){if(-1!==this.id)return this.id;if("number"===typeof a)return a};c([b.property({type:String,json:{origins:{"web-scene":{write:!0}}}})],a.prototype,"title",void 0);c([b.reader("service","title",["alias","name"])],a.prototype,"readTitle",null);c([b.property()],a.prototype,"layer",void 0);c([b.property({type:Number,readOnly:!0,json:{read:!1,write:{ignoreOrigin:!0}}})],a.prototype,"id",void 0);c([b.reader("service","id")],
a.prototype,"readIdOnlyOnce",null);c([b.property(h.readOnlyService(String))],a.prototype,"modelName",void 0);c([b.property({type:Boolean,json:{read:{source:"visibility"},write:{target:"visibility"}}})],a.prototype,"visible",void 0);c([b.property({type:Number,json:{write:!0}})],a.prototype,"opacity",void 0);return a=c([b.subclass("esri.layers.buildingSublayers.BuildingSublayer")],a)}(b.declared(f.IdentifiableMixin(g.MultiOriginJSONSupport)))});