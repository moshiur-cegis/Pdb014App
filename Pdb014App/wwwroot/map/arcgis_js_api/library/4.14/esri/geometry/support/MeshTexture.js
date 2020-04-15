// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../core/tsSupport/declareExtendsHelper ../../core/tsSupport/decorateHelper @dojo/framework/shim/WeakMap ../../core/compilerUtils ../../core/JSONSupport ../../core/urlUtils ../../core/accessorSupport/decorators ../../views/support/screenshotUtils".split(" "),function(t,u,l,e,m,n,p,h,d,q){var g=new m.default,r=0;return function(k){function b(a){a=k.call(this,a)||this;a.wrap="repeat";return a}l(b,k);f=b;Object.defineProperty(b.prototype,"url",{get:function(){return this._get("url")||
null},set:function(a){this._set("url",a);a&&this._set("data",null)},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,"data",{get:function(){return this._get("data")||null},set:function(a){this._set("data",a);a&&this._set("url",null)},enumerable:!0,configurable:!0});b.prototype.writeData=function(a,c,b,d){a instanceof HTMLImageElement?a={type:"image-element",src:h.toJSON(a.src,d)}:a instanceof HTMLCanvasElement?(a=a.getContext("2d").getImageData(0,0,a.width,a.height),a={type:"canvas-element",
imageData:this.encodeImageData(a)}):a={type:"image-data",imageData:this.encodeImageData(a)};c[b]=a};b.prototype.readData=function(a){switch(a.type){case "image-element":var c=new Image;c.src=a.src;return c;case "canvas-element":return a=this.decodeImageData(a.imageData),c=document.createElement("canvas"),c.width=a.width,c.height=a.height,c.getContext("2d").putImageData(a,0,0),c;case "image-data":return this.decodeImageData(a.imageData);default:n.neverReached(a)}};Object.defineProperty(b.prototype,
"transparent",{get:function(){var a=this.data,c=this.url;return a instanceof HTMLCanvasElement?this.imageDataContainsTransparent(a.getContext("2d").getImageData(0,0,a.width,a.height)):a instanceof ImageData?this.imageDataContainsTransparent(a):c&&(a=c.substr(c.length-4,4).toLowerCase(),c=c.substr(0,15).toLocaleLowerCase(),".png"===a||"data:image/png;"===c)?!0:!1},set:function(a){null!=a?this._override("transparent",a):this._clearOverride("transparent")},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,
"contentHash",{get:function(){var a=this,c="string"===typeof this.wrap?this.wrap:"object"===typeof this.wrap?this.wrap.horizontal+"/"+this.wrap.vertical:"",b=function(b){void 0===b&&(b="");return"d:"+b+",t:"+a.transparent+",w:"+c};if(null!=this.url)return b(this.url);if(null!=this.data){if(this.data instanceof HTMLImageElement)return b(this.data.src);g.has(this.data)||g.set(this.data,++r);return b(g.get(this.data))}return b()},enumerable:!0,configurable:!0});b.prototype.clone=function(){return new f({url:this.url,
data:this.data,wrap:this.cloneWrap()})};b.prototype.cloneWithDeduplication=function(a){var c=a.get(this);if(c)return c;c=new f({url:this.url,data:this.data,wrap:this.cloneWrap()});a.set(this,c);return c};b.prototype.cloneWrap=function(){return"string"===typeof this.wrap?this.wrap:{horizontal:this.wrap.horizontal,vertical:this.wrap.vertical}};b.prototype.encodeImageData=function(a){for(var c="",b=0;b<a.data.length;b++)c+=String.fromCharCode(a.data[b]);return{data:btoa(c),width:a.width,height:a.height}};
b.prototype.decodeImageData=function(a){for(var b=atob(a.data),d=new Uint8ClampedArray(b.length),e=0;e<b.length;e++)d[e]=b.charCodeAt(e);return q.wrapImageData(d,a.width,a.height)};b.prototype.imageDataContainsTransparent=function(a){for(var b=3;b<a.data.length;b+=4)if(255!==a.data[b])return!0;return!1};var f;e([d.property({type:String,json:{write:h.write}})],b.prototype,"url",null);e([d.property({json:{write:{overridePolicy:function(){return{enabled:!this.url}}}}}),d.property()],b.prototype,"data",
null);e([d.writer("data")],b.prototype,"writeData",null);e([d.reader("data")],b.prototype,"readData",null);e([d.property({type:Boolean,dependsOn:["data","url"],json:{write:{overridePolicy:function(){return{enabled:this._isOverridden("transparent")}}}}})],b.prototype,"transparent",null);e([d.property({json:{write:!0}})],b.prototype,"wrap",void 0);e([d.property({readOnly:!0,dependsOn:["url","data","wrap","transparent"]})],b.prototype,"contentHash",null);return b=f=e([d.subclass("esri.geometry.support.MeshTexture")],
b)}(d.declared(p.JSONSupport))});