// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../core/tsSupport/declareExtendsHelper ../core/tsSupport/decorateHelper ../core/tsSupport/assignHelper ../request ../core/maybe ../core/accessorSupport/decorators ../geometry/support/normalizeUtils ./Task ./support/ImageServiceIdentifyResult".split(" "),function(r,t,h,k,f,l,m,g,n,p,q){return function(c){function a(){return null!==c&&c.apply(this,arguments)||this}h(a,c);a.prototype.execute=function(a,c){var e=this;return n.normalizeCentralMeridian(a.geometry?[a.geometry]:[]).then(function(d){var b=
a.toJSON();d=d&&d[0];m.isSome(d)&&(b.geometry=JSON.stringify(d.toJSON()));b=e._encode(f({f:"json"},e.parsedUrl.query,b));b=f({query:b},e.requestOptions,c);return l(e.parsedUrl.path+"/identify",b)}).then(function(a){return q.fromJSON(a.data)})};return a=k([g.subclass("esri.tasks.ImageServiceIdentifyTask")],a)}(g.declared(p))});