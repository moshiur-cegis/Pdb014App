// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../../core/libs/gl-matrix-2/vec2 ../../../../../../core/libs/gl-matrix-2/vec2f32 ../../definitions ../../number ../../collisions/BoundingBox".split(" "),function(A,B,c,C,G,f,I){Object.defineProperty(B,"__esModule",{value:!0});var a=C.vec2f32.create();A=function(){function x(a,e,c,f,t,x,D,n,l,E,g,h,u,p,k){this.anchorX=a;this.anchorY=e;this.angle=c;this.bounds=f;this.minZoom=t;this.maxZoom=x;this.materialKey=D;this.vertexOffsetUpperLeft=n;this.vertexOffsetUpperRight=
l;this.vertexOffsetLowerLeft=E;this.vertexOffsetLowerRight=g;this.texFontSizeUpperLeft=h;this.texFontSizeUpperRight=u;this.texFontSizeLowerLeft=p;this.texFontSizeLowerRight=k}x.from=function(m,e,A,B,t,C,D,n,l,E,g,h,u,p,k){void 0===p&&(p=!1);void 0===k&&(k=!1);var b=n.rect,d=n.metrics;t=-1===t?255:Math.floor(180*t/Math.PI/360*254);var y=Math.round(b.x/4),z=Math.round(b.y/4);n=y+Math.round(b.width/4);var H=z+Math.round(b.height/4),v=-24-d.top,w=d.left,q=-d.top,r=b.width,b=b.height;l||(k||(v=0),w=4,
r=d.width);m+=w;l=k?e+q:e+v;r=m+r;v=l;e=m;q=l+b;b=r;k=q;var w=e+d.width,F=q-d.height,J=d.width*h/24,d=d.height*h/24;g&&(c.vec2.transformMat2d(a,c.vec2.set(a,m,l),g),m=a[0],l=a[1],c.vec2.transformMat2d(a,c.vec2.set(a,r,v),g),r=a[0],v=a[1],c.vec2.transformMat2d(a,c.vec2.set(a,e,q),g),e=a[0],q=a[1],c.vec2.transformMat2d(a,c.vec2.set(a,b,k),g),b=a[0],k=a[1],c.vec2.transformMat2d(a,c.vec2.set(a,w,F),g),w=a[0],F=a[1]);g=p?new I.default(w,F,J+G.COLLISION_BOX_PADDING,d+G.COLLISION_BOX_PADDING):null;p=f.i1616to32(8*
m,8*l);d=f.i1616to32(8*r,8*v);m=f.i1616to32(8*e,8*q);e=f.i1616to32(8*b,8*k);b=f.i8888to32(y,z,h,u);z=f.i8888to32(n,z,h,u);y=f.i8888to32(y,H,h,u);h=f.i8888to32(n,H,h,u);return new x(A|0,B|0,t,g,C,D,E,p,d,m,e,b,z,y,h)};return x}();B.default=A});