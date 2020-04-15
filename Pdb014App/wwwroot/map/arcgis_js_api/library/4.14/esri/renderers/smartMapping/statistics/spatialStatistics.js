// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../core/promiseUtils","../../../geometry/support/coordsUtils"],function(y,z,x,v){function p(b,g){void 0===g&&(g=!1);var d=[];if(g)for(var c=0;c<b.length;c++){var e=b[c];e.geometry&&d.push.apply(d,e.geometry.points)}else d=b.map(function(a){return a.geometry});b=[];for(var c=[],e=Infinity,h=-Infinity,k=0,a=0,l=0,m=0,t=0,p=d;t<p.length;t++){var n=p[t];if(n){g?(b[0]=n[0],b[1]=n[1]):(b[0]=n.x,b[1]=n.y);for(var q=Infinity,r=-Infinity,u=0,w=d;u<w.length;u++){var f=w[u];
f!==n&&f&&(g?(c[0]=f[0],c[1]=f[1]):(c[0]=f.x,c[1]=f.y),f=v.getLength(b,c),0<f&&(f<q&&(q=f),f<e&&(e=f),f>r&&(r=f),f>h&&(h=f)))}Infinity!==q&&(++l,k+=q);-Infinity!==r&&(++m,a+=r)}}return{minDistance:Infinity!==e?e:null,maxDistance:-Infinity!==h?h:null,avgMinDistance:l?k/l:null,avgMaxDistance:m?a/m:null}}return function(b){var g=b.features,d=null;switch(b.geometryType){case "point":d=p(g);break;case "multipoint":d=p(g,!0);break;case "polyline":for(var d=b=0,c=Infinity,e=-Infinity,h=0;h<g.length;h++){var k=
g[h].geometry;if(k){for(var a=0,l=0,k=k.paths;l<k.length;l++){var m=v.getPathLength(k[l]);0<m&&(a+=m)}0<a&&(++b,d+=a,a<c&&(c=a),a>e&&(e=a))}}d={minLength:Infinity!==c?c:null,maxLength:-Infinity!==e?e:null,avgLength:b?d/b:null};break;case "polygon":d=b=0;c=Infinity;e=-Infinity;for(h=0;h<g.length;h++)if(a=g[h].geometry)if(a=a.extent)a=Math.sqrt(a.width*a.height),0<a&&(++b,d+=a,a<c&&(c=a),a>e&&(e=a));d={minSize:Infinity!==c?c:null,maxSize:-Infinity!==e?e:null,avgSize:b?d/b:null}}return x.resolve(d)}});