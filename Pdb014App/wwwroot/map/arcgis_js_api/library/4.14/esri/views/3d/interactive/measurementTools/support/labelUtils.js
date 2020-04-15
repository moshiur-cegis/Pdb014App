// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../core/screenUtils ../../../../../core/libs/gl-matrix-2/vec2 ../../../../../core/libs/gl-matrix-2/vec3 ../../../../../core/libs/gl-matrix-2/vec3f64 ./viewUtils".split(" "),function(A,d,g,e,y,z,q){function r(a,b,l){a.projectPoint(b,c);if(0>c[2]||1<c[2])return!1;a.renderToScreen(c,l);return!0}function t(f,b,l,u,d,g){if(!b)return!1;q.screenSpaceTangent(b.start,b.end,m,f);e.vec2.set(a,-m[1],m[0]);var h=!1;switch(u){case "top":h=0>a[1];break;case "bottom":h=0<a[1];
break;case "left":h=0<a[0];break;case "right":h=0>a[0]}h&&e.vec2.negate(a,a);if(0===e.vec2.length(a))switch(u){case "top":a[1]=1;break;case "bottom":a[1]=-1;break;case "left":a[0]=-1;break;case "right":a[0]=1}f.projectPoint(b.origin,c);if(0>c[2]||1<c[2])return!1;f.renderToScreen(c,d);e.vec2.scale(a,a,l*f.pixelRatio);e.vec2.add(a,a,c);f.renderToScreen(a,g);return!0}function v(f,b,l,d,h,g){if(!b||!l)return!1;q.screenSpaceTangent(b.end,b.start,m,f);q.screenSpaceTangent(l.start,l.end,w,f);e.vec2.add(a,
m,w);e.vec2.negate(a,a);e.vec2.normalize(a,a);f.projectPoint(b.end,c);if(0>c[2]||1<c[2])return!1;f.renderToScreen(c,h);e.vec2.scale(a,a,d*f.pixelRatio);e.vec2.add(a,a,c);f.renderToScreen(a,g);return!0}Object.defineProperty(d,"__esModule",{value:!0});d.mirrorPosition=function(a){switch(a){case "top":return"bottom";case "right":return"left";case "bottom":return"top";case "left":return"right"}};d.computeLabelPositionFromPoint=r;d.positionLabelOnPoint=function(a,b,c){(b=r(c,b,k))&&a.updatePosition(k,
null);return b};d.computeLabelPositionFromSegment=t;d.positionLabelOnSegment=function(a,b,c,e,d){(b=t(d,b,c,e,k,n))&&a.updatePosition(k,n);return b};d.computeLabelPositionFromCorner=v;d.computeLabelPositionFromPlane=function(f,b,d,g,h,k){f.projectPoint(b,c);y.vec3.add(x,b,d);f.projectPoint(x,p);if(0>c[2]||1<c[2]||0>p[2]||1<p[2])return!1;e.vec2.subtract(a,p,c);e.vec2.normalize(a,a);f.renderToScreen(c,h);e.vec2.scale(a,a,g*f.pixelRatio);e.vec2.add(a,a,c);f.renderToScreen(a,k);return!0};d.positionLabelOnCorner=
function(a,b,c,d,e){(b=v(e,b,c,d,k,n))&&a.updatePosition(k,n);return b};var m=g.createRenderScreenPointArray(),w=g.createRenderScreenPointArray(),a=g.createRenderScreenPointArray(),c=g.createRenderScreenPointArray3(),p=g.createRenderScreenPointArray3(),x=z.vec3f64.create(),k=g.createScreenPointArray(),n=g.createScreenPointArray()});