// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../core/tsSupport/declareExtendsHelper ../../core/tsSupport/decorateHelper ../../core/JSONSupport ../../core/accessorSupport/decorators".split(" "),function(d,b,f,e,g,c){Object.defineProperty(b,"__esModule",{value:!0});d=function(d){function a(a){return d.call(this,a)||this}f(a,d);b=a;a.prototype.clone=function(){return new b({name:this.name,fields:this.fields,isAscending:this.isAscending,isUnique:this.isUnique,description:this.description})};var b;e([c.property({constructOnly:!0})],
a.prototype,"name",void 0);e([c.property({constructOnly:!0})],a.prototype,"fields",void 0);e([c.property({constructOnly:!0})],a.prototype,"isAscending",void 0);e([c.property({constructOnly:!0})],a.prototype,"isUnique",void 0);e([c.property({constructOnly:!0})],a.prototype,"description",void 0);return a=b=e([c.subclass("esri.layers.support.FeatureIndex")],a)}(c.declared(g.JSONSupport));b.FeatureIndex=d;b.default=d});