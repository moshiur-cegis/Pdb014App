// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/assignHelper ../../../core/tsSupport/generatorHelper ../../../core/tsSupport/awaiterHelper ../../../geometry/support/aaBoundingRect ../featureConversionUtils ../OptimizedGeometry ./QueryEngine ./utils".split(" "),function(H,l,I,J,K,z,a,E,q,A){function v(b,c,u,B,w,h){b.lengths.length&&(b.lengths.length=0);b.coords.length&&(b.coords.length=0);if(!c||!c.coords.length)return null;var p=c.coords;c=c.lengths;if(!c.length)return b.coords[0]=a.quantizeX(h,p[0]),
b.coords[1]=a.quantizeY(h,p[1]),b.coords.length=u,b;for(var d,g,f,n,m=0,k,e=0,y=0;y<c.length;y++){var C=c[y];if(!(C<B)){k=e;f=d=a.quantizeX(h,p[m]);n=g=a.quantizeY(h,p[m+1]);b.coords[k]=f;b.coords[k+1]=n;m+=u;f=a.quantizeX(h,p[m]);n=a.quantizeY(h,p[m+1]);var r=f-d,t=n-g,x=t/r;k+=2;b.coords[k]=r;b.coords[k+1]=t;d=f;g=n;for(var m=m+u,l=2;l<C;l++){f=a.quantizeX(h,p[m]);n=a.quantizeY(h,p[m+1]);if(f!==d||n!==g){d=f-d;g=n-g;var q=g/d,x=x===q||!isFinite(x)&&!isFinite(q),v=(0<=t&&0<=g||0>=t&&0>=g)&&(0<=r&&
0<=d||0>=r&&0>=d);x&&(w||v)?(r+=d,t+=g):(r=d,t=g,k+=2);b.coords[k]=r;b.coords[k+1]=t;x=q;d=f;g=n}m+=u}f=(k+2-e)/2;f>=B&&(b.lengths.push(f),e=k+2)}}b.coords.length>e&&(b.coords.length=e);return b.coords.length?b:null}Object.defineProperty(l,"__esModule",{value:!0});var D=new E.default,F={esriGeometryPoint:a.convertToPoint,esriGeometryPolyline:a.convertToPolyline,esriGeometryPolygon:a.convertToPolygon,esriGeometryMultipoint:a.convertToMultipoint};l.executeTileQueryForIds=function(b,c,u){c=z.pad(c.bounds,
u.pixelBuffer*c.resolution,z.create());var a=[];b.featureStore.forEachInBounds(c,function(c){return a.push(b.featureAdapter.getObjectId(c))});return a};l.createTileFeatures=function(b,c,a,l,w,h,p,d,g){var f=F[a.geometryType],n=G[a.geometryType],m="esriGeometryPolygon"===a.geometryType&&!d,k=a.hasZ?a.hasM?4:3:a.hasM?3:2;p&&!h?l.forEachInBounds(w,function(e){if(!c.has(e.objectId)){var f=A.getCentroid(a,e,g),d=e.attributes;f&&(c.add(e.objectId),b.push(new q.Feature(d,e.localId,null,f)))}}):h&&!p?l.forEachInBounds(w,
function(a){if(!c.has(a.objectId)){var e=a.attributes,d=f(v(D,a.geometry,k,n,m,g),!1,!1);d&&(c.add(a.objectId),b.push(new q.Feature(e,a.localId,d,null)))}}):l.forEachInBounds(w,function(e){if(!c.has(e.objectId)){var d=A.getCentroid(a,e,g),l=e.attributes,h=f(v(D,e.geometry,k,n,m,g),!1,!1);h&&d&&(c.add(e.objectId),b.push(new q.Feature(l,e.localId,h,d)))}})};var G={esriGeometryPoint:0,esriGeometryPolyline:2,esriGeometryPolygon:3,esriGeometryMultipoint:0};l.quantizeOptimizedGeometryForDisplay=v});