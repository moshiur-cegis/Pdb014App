// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/decorateHelper ../../../core/JSONSupport ../../../core/screenUtils ../../../core/accessorSupport/decorators".split(" "),function(k,l,f,c,g,h,b){return function(e){function a(a){a=e.call(this,a)||this;a.label=null;a.size=null;a.value=null;return a}f(a,e);d=a;a.prototype.clone=function(){return new d({label:this.label,size:this.size,value:this.value})};var d;c([b.property({type:String,json:{write:!0}})],a.prototype,
"label",void 0);c([b.property({type:Number,cast:h.toPt,json:{write:!0}})],a.prototype,"size",void 0);c([b.property({type:Number,json:{write:!0}})],a.prototype,"value",void 0);return a=d=c([b.subclass("esri.renderers.visualVariables.support.SizeStop")],a)}(b.declared(g.JSONSupport))});