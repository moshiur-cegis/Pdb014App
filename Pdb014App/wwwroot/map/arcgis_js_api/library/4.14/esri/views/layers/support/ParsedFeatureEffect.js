// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/decorateHelper ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/assignHelper ../../../core/Error ../../../core/JSONSupport ../../../core/Logger ../../../core/maybe ../../../core/accessorSupport/decorators ../../../core/libs/gl-matrix-2/mat4 ../../../core/libs/gl-matrix-2/mat4f32 ./cssFilterParser".split(" "),function(x,y,f,n,h,p,q,r,t,e,d,c,u){var l=r.getLogger("esri.views.layers.support.ParsedFeatureEffect"),v={grayscale:function(a){a=
1-a.amount;a=c.mat4f32.fromValues(.2126+.7874*a,.7152-.7152*a,.0722-.0722*a,0,.2126-.2126*a,.7152+.2848*a,.0722-.0722*a,0,.2126-.2126*a,.7152-.7152*a,.0722+.9278*a,0,0,0,0,1);return d.mat4.transpose(a,a)},sepia:function(a){a=1-a.amount;a=c.mat4f32.fromValues(.393+.607*a,.769-.769*a,.189-.189*a,0,.349-.349*a,.686+.314*a,.168-.168*a,0,.272-.272*a,.534-.534*a,.131+.869*a,0,0,0,0,1);return d.mat4.transpose(a,a)},saturate:function(a){a=a.amount;a=c.mat4f32.fromValues(.213+.787*a,.715-.715*a,.072-.072*
a,0,.213-.213*a,.715+.285*a,.072-.072*a,0,.213-.213*a,.715-.715*a,.072+.928*a,0,0,0,0,1);return d.mat4.transpose(a,a)},"hue-rotate":function(a){var b=Math.sin(a.angle*Math.PI/180);a=Math.cos(a.angle*Math.PI/180);b=c.mat4f32.fromValues(.213+.787*a-.213*b,.715-.715*a-.715*b,.072-.072*a+.928*b,0,.213-.213*a+.143*b,.715+.285*a+.14*b,.072-.072*a-.283*b,0,.213-.213*a-.787*b,.715-.715*a+.715*b,.072+.928*a+.072*b,0,0,0,0,1);return d.mat4.transpose(b,b)},invert:function(a){var b=1-2*a.amount;a=a.amount;b=
c.mat4f32.fromValues(b,0,0,a,0,b,0,a,0,0,b,a,0,0,0,1);return d.mat4.transpose(b,b)},brightness:function(a){a=a.amount;a=c.mat4f32.fromValues(a,0,0,0,0,a,0,0,0,0,a,0,0,0,0,1);return d.mat4.transpose(a,a)},contrast:function(a){a=a.amount;a=c.mat4f32.fromValues(a,0,0,.5-.5*a,0,a,0,.5-.5*a,0,0,a,.5-.5*a,0,0,0,1);return d.mat4.transpose(a,a)}};return function(a){function b(){var b=null!==a&&a.apply(this,arguments)||this;b.customTransforms=null;b.done=!0;return b}n(b,a);g=b;b.fromString=function(a){var b=
[],c=null;try{for(var d=0,m=u.parse(a);d<m.length;d++){var k=m[d];"opacity"===k.type?c=k:b.push(k)}}catch(w){l.error(new p("invalid-type","Encountered an error when parsing css",w))}return new g({transforms:b,opacity:c})};b.prototype.getOpacity=function(){return t.isSome(this.opacity)?this.opacity.amount:1};b.prototype.getColorMatrix=function(){var a=this;return(this.transforms||[]).map(function(a){return h({},a)}).reverse().reduce(function(b,c){return d.mat4.multiply(b,b,a._getFactory(c)(c))},c.mat4f32.create())};
b.prototype.clone=function(){return new g({transforms:this.transforms&&this.transforms.map(function(a){return h({},a)}),customTransforms:this.customTransforms&&this.customTransforms.map(function(a){return h({},a)})})};b.prototype._getFactory=function(a){var b=v[a.type];if(b)return b;if(this.customTransforms)for(var b=function(b){if(b.type===a.type){b=c.mat4f32.fromValues.apply(c.mat4f32,b.matrix);var e=d.mat4.transpose(b,b);return{value:function(){return e}}}},e=0,f=this.customTransforms;e<f.length;e++){var g=
b(f[e]);if("object"===typeof g)return g.value}l.error("invalid-type","No effect "+a.type+" exists");return function(){return c.mat4f32.create()}};var g;f([e.property()],b.prototype,"opacity",void 0);f([e.property()],b.prototype,"transforms",void 0);f([e.property()],b.prototype,"customTransforms",void 0);return b=g=f([e.subclass("esri.views.layers.support.ParsedFeatureEffect")],b)}(e.declared(q.JSONSupport))});