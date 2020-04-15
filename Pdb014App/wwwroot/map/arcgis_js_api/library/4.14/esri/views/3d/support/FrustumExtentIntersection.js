// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/compilerUtils ../../../core/mathUtils ../../../core/libs/gl-matrix-2/mat4 ../../../core/libs/gl-matrix-2/mat4f64 ../../../core/libs/gl-matrix-2/vec3 ../../../core/libs/gl-matrix-2/vec3f64 ../../../geometry/support/aaBoundingBox ../../../geometry/support/aaBoundingRect ./earthUtils ./geometryUtils ./intersectionUtils ./mathUtils ./projectionUtils".split(" "),function(q,p,z,v,A,w,e,l,t,B,n,f,C,D,x){Object.defineProperty(p,"__esModule",{value:!0});q=.5*Math.PI;var E=
q/Math.PI*180,F=q*n.earthRadius,G=.9*n.earthRadius;n=function(){function k(a){this.renderCoordsHelper=a.renderCoordsHelper;this.extent=Array(4);this.planes=Array(6);this.maxSpan=0;this.center={origin:l.vec3f64.create(),direction:l.vec3f64.create()};for(a=0;4>a;a++)this.extent[a]={origin:l.vec3f64.create(),direction:l.vec3f64.create(),cap:{next:null,direction:l.vec3f64.create()}},this.planes[a]=f.plane.create();this.planes[4]=f.plane.create();this.planes[5]=f.plane.create();this.planesWithoutFar=this.planes.slice(0,
5)}k.prototype.update=function(a,h,c,r){void 0===r&&(r=!0);var b=this.extent;this.toRenderBoundingExtent(a,h,c);e.vec3.add(this.center.origin,b[0].origin,b[2].origin);e.vec3.scale(this.center.origin,this.center.origin,.5);this.renderCoordsHelper.worldUpAtPosition(this.center.origin,this.center.direction);r||e.vec3.scale(this.center.direction,this.center.direction,-1);for(c=0;4>c;c++){var d=b[c];this.renderCoordsHelper.worldUpAtPosition(d.origin,d.direction);var g=b[3===c?0:c+1];d.cap.next=g.origin;
D.directionFromTo(d.cap.direction,d.origin,g.origin);f.plane.fromVectorsAndPoint(d.direction,d.cap.direction,d.origin,this.planes[c]);r||e.vec3.scale(d.direction,d.direction,-1)}f.plane.fromVectorsAndPoint(b[0].cap.direction,b[1].cap.direction,b[0].origin,this.planes[4]);r?f.plane.negate(this.planes[4],this.planes[5]):(f.plane.copy(this.planes[4],this.planes[5]),f.plane.negate(this.planes[4],this.planes[4]));this.maxSpan=Math.max(Math.abs(a[0]-a[2]),Math.abs(a[1]-a[3]));this.maxSpanSpatialReference=
h};k.prototype.isVisibleInFrustum=function(a,h){void 0===h&&(h=!1);if(null==a)return!1;if("global"===this.renderCoordsHelper.type){if(this.maxSpan>(this.maxSpanSpatialReference.isGeographic?E:F))return!0;if(a.altitude>=G)return this.isVisibleInFrustumGlobal(a)}if(0===this.maxSpan){var c=this.extent[0];return!h&&a.intersectsRay(f.ray.wrap(c.origin,c.direction))?!0:!1}for(var b=0;b<this.extent.length;b++)if(c=this.extent[b],!h&&a.intersectsRay(f.ray.wrap(c.origin,c.direction))||a.intersectsLineSegment(f.lineSegment.fromPoints(c.origin,
c.cap.next,H),c.cap.direction))return!0;h=h?this.planes:this.planesWithoutFar;for(b=0;b<a.lines.length;b++)if(c=a.lines[b],C.frustumLineSegment(h,c.origin,c.endpoint,c.direction))return!0;return!1};k.prototype.toRenderBoundingExtentGlobal=function(a,h,c){B.center(a,g);g[2]=c;x.computeLinearTransformation(h,g,u,this.renderCoordsHelper.spatialReference);A.mat4.invert(y,u);t.empty(b);for(var f=0,k=I;f<k.length;f++)for(var d=k[f],l=d.x0,n=d.x1,q=d.y0,d=d.y1,m=0;5>m;m++){var p=m/4;g[0]=v.lerp(a[l],a[n],
p);g[1]=v.lerp(a[q],a[d],p);g[2]=c;x.vectorToVector(g,h,g,this.renderCoordsHelper.spatialReference);e.vec3.transformMat4(g,g,y);t.expandPointInPlace(b,g)}e.vec3.set(this.extent[0].origin,b[0],b[1],b[2]);e.vec3.set(this.extent[1].origin,b[3],b[1],b[2]);e.vec3.set(this.extent[2].origin,b[3],b[4],b[2]);e.vec3.set(this.extent[3].origin,b[0],b[4],b[2]);for(m=0;4>m;++m)e.vec3.transformMat4(this.extent[m].origin,this.extent[m].origin,u)};k.prototype.toRenderBoundingExtentLocal=function(a,b){e.vec3.set(this.extent[0].origin,
a[0],a[1],b);e.vec3.set(this.extent[1].origin,a[2],a[1],b);e.vec3.set(this.extent[2].origin,a[2],a[3],b);e.vec3.set(this.extent[3].origin,a[0],a[3],b)};k.prototype.toRenderBoundingExtent=function(a,b,c){switch(this.renderCoordsHelper.type){case "global":this.toRenderBoundingExtentGlobal(a,b,c);break;case "local":this.toRenderBoundingExtentLocal(a,c);break;default:z.neverReached(this.renderCoordsHelper.type)}};k.prototype.isVisibleInFrustumGlobal=function(a){if(0>e.vec3.dot(this.center.direction,a.direction))return!0;
for(var b=0;4>b;b++)if(0>e.vec3.dot(this.extent[b].direction,a.direction))return!0;return!1};return k}();p.FrustumExtentIntersection=n;var I=[{x0:0,y0:1,x1:2,y1:1},{x0:0,y0:3,x1:2,y1:3},{x0:0,y0:1,x1:0,y1:3},{x0:2,y0:1,x1:2,y1:3}],g=l.vec3f64.create(),u=w.mat4f64.create(),y=w.mat4f64.create(),b=t.create(),H=f.lineSegment.create();p.default=n});