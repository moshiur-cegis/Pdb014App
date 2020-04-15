// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../core/has ../../core/maybe ./enums ./InstanceCounter ./renderState ./capabilities/isWebGL2Context ./capabilities/load".split(" "),function(m,n,p,g,f,q,h,k,l){return function(){function b(a,c){var d=this;this.gl=null;this._blendEnabled=!1;this._blendColorState={r:0,g:0,b:0,a:0};this._blendFunctionState={srcRGB:1,dstRGB:0,srcAlpha:1,dstAlpha:0};this._blendEquationState={mode:32774,modeAlpha:32774};this._colorMaskState={r:!0,g:!0,b:!0,a:!0};this._polygonCullingEnabled=!1;
this._cullFace=1029;this._frontFace=2305;this._scissorTestEnabled=!1;this._scissorRect={x:0,y:0,width:0,height:0};this._depthTestEnabled=!1;this._depthFunction=513;this._clearDepth=1;this._depthWriteEnabled=!0;this._depthRange={zNear:0,zFar:1};this._viewport=null;this._polygonOffsetFillEnabled=this._stencilTestEnabled=!1;this._polygonOffset=[0,0];this._stencilFunction={face:1032,func:519,ref:0,mask:1};this._clearStencil=0;this._stencilWriteMask=1;this._stencilOperation={face:1032,fail:7680,zFail:7680,
zPass:7680};this._clearColor={r:0,g:0,b:0,a:0};this._activeRenderbuffer=this._activeFramebuffer=this._activeIndexBuffer=this._activeVertexBuffer=this._activeShaderProgram=null;this._activeTextureUnit=0;this._textureUnitMap={};this._numOfTriangles=this._numOfDrawCalls=0;this.contextVersion=k.default(a)?"webgl2":"webgl";this.gl=a;a instanceof WebGLRenderingContext&&this.gl.getExtension("OES_element_index_uint");this._capabilities=l.loadCapabilities(a,c);a=this.gl.getParameter(this.gl.VIEWPORT);this._viewport=
{x:a[0],y:a[1],width:a[2],height:a[3]};this._stateTracker=new h.StateTracker({setBlending:function(a){a?(d.setBlendingEnabled(!0),d.setBlendEquationSeparate(a.opRgb,a.opAlpha),d.setBlendFunctionSeparate(a.srcRgb,a.dstRgb,a.srcAlpha,a.dstAlpha),a=a.color,d.setBlendColor(a.r,a.g,a.b,a.a)):d.setBlendingEnabled(!1)},setCulling:function(a){a?(d.setFaceCullingEnabled(!0),d.setCullFace(a.face),d.setFrontFace(a.mode)):d.setFaceCullingEnabled(!1)},setPolygonOffset:function(a){a?(d.setPolygonOffsetFillEnabled(!0),
d.setPolygonOffset(a.factor,a.units)):d.setPolygonOffsetFillEnabled(!1)},setDepthTest:function(a){a?(d.setDepthTestEnabled(!0),d.setDepthFunction(a.func)):d.setDepthTestEnabled(!1)},setStencilTest:function(a){if(a){d.setStencilTestEnabled(!0);var c=a.function;d.setStencilFunction(c.func,c.ref,c.mask);a=a.operation;d.setStencilOp(a.fail,a.zFail,a.zPass)}else d.setStencilTestEnabled(!1)},setDepthWrite:function(a){a?(d.setDepthWriteEnabled(!0),d.setDepthRange(a.zNear,a.zFar)):d.setDepthWriteEnabled(!1)},
setColorWrite:function(a){a?d.setColorMask(a.r,a.g,a.b,a.a):d.setColorMask(!1,!1,!1,!1)},setStencilWrite:function(a){a?d.setStencilWriteMask(a.mask):d.setStencilWriteMask(0)}});this.enforceState()}Object.defineProperty(b.prototype,"contextAttributes",{get:function(){return this.gl.getContextAttributes()},enumerable:!0,configurable:!0});Object.defineProperty(b.prototype,"parameters",{get:function(){if(!this._parameters){var a=this.capabilities.textureFilterAnisotropic;this._parameters={versionString:this.gl.getParameter(this.gl.VERSION),
maxVertexTextureImageUnits:this.gl.getParameter(this.gl.MAX_VERTEX_TEXTURE_IMAGE_UNITS),maxVertexAttributes:this.gl.getParameter(this.gl.MAX_VERTEX_ATTRIBS),maxMaxAnisotropy:a?this.gl.getParameter(a.MAX_TEXTURE_MAX_ANISOTROPY):void 0,maxTextureImageUnits:this.gl.getParameter(this.gl.MAX_TEXTURE_IMAGE_UNITS)}}return this._parameters},enumerable:!0,configurable:!0});b.prototype.dispose=function(){this.bindVAO(null);this.unbindBuffer(34962);this.unbindBuffer(34963);this._textureUnitMap={};this.gl=null};
b.prototype.setPipelineState=function(a){this._stateTracker.setPipeline(a)};b.prototype.setBlendingEnabled=function(a){this._blendEnabled!==a&&(!0===a?this.gl.enable(this.gl.BLEND):this.gl.disable(this.gl.BLEND),this._blendEnabled=a,this._stateTracker.invalidateBlending())};b.prototype.setBlendColor=function(a,c,d,b){if(a!==this._blendColorState.r||c!==this._blendColorState.g||d!==this._blendColorState.b||b!==this._blendColorState.a)this.gl.blendColor(a,c,d,b),this._blendColorState.r=a,this._blendColorState.g=
c,this._blendColorState.b=d,this._blendColorState.a=b,this._stateTracker.invalidateBlending()};b.prototype.setBlendFunction=function(a,c){if(a!==this._blendFunctionState.srcRGB||c!==this._blendFunctionState.dstRGB)this.gl.blendFunc(a,c),this._blendFunctionState.srcRGB=a,this._blendFunctionState.srcAlpha=a,this._blendFunctionState.dstRGB=c,this._blendFunctionState.dstAlpha=c,this._stateTracker.invalidateBlending()};b.prototype.setBlendFunctionSeparate=function(a,c,d,b){if(this._blendFunctionState.srcRGB!==
a||this._blendFunctionState.srcAlpha!==d||this._blendFunctionState.dstRGB!==c||this._blendFunctionState.dstAlpha!==b)this.gl.blendFuncSeparate(a,c,d,b),this._blendFunctionState.srcRGB=a,this._blendFunctionState.srcAlpha=d,this._blendFunctionState.dstRGB=c,this._blendFunctionState.dstAlpha=b,this._stateTracker.invalidateBlending()};b.prototype.setBlendEquation=function(a){this._blendEquationState.mode!==a&&(this.gl.blendEquation(a),this._blendEquationState.mode=a,this._blendEquationState.modeAlpha=
a,this._stateTracker.invalidateBlending())};b.prototype.setBlendEquationSeparate=function(a,c){if(this._blendEquationState.mode!==a||this._blendEquationState.modeAlpha!==c)this.gl.blendEquationSeparate(a,c),this._blendEquationState.mode=a,this._blendEquationState.modeAlpha=c,this._stateTracker.invalidateBlending()};b.prototype.setColorMask=function(a,c,d,b){if(this._colorMaskState.r!==a||this._colorMaskState.g!==c||this._colorMaskState.b!==d||this._colorMaskState.a!==b)this.gl.colorMask(a,c,d,b),
this._colorMaskState.r=a,this._colorMaskState.g=c,this._colorMaskState.b=d,this._colorMaskState.a=b,this._stateTracker.invalidateColorWrite()};b.prototype.setClearColor=function(a,c,d,b){if(this._clearColor.r!==a||this._clearColor.g!==c||this._clearColor.b!==d||this._clearColor.a!==b)this.gl.clearColor(a,c,d,b),this._clearColor.r=a,this._clearColor.g=c,this._clearColor.b=d,this._clearColor.a=b};b.prototype.setFaceCullingEnabled=function(a){this._polygonCullingEnabled!==a&&(!0===a?this.gl.enable(this.gl.CULL_FACE):
this.gl.disable(this.gl.CULL_FACE),this._polygonCullingEnabled=a,this._stateTracker.invalidateCulling())};b.prototype.setPolygonOffsetFillEnabled=function(a){this._polygonOffsetFillEnabled!==a&&(!0===a?this.gl.enable(this.gl.POLYGON_OFFSET_FILL):this.gl.disable(this.gl.POLYGON_OFFSET_FILL),this._polygonOffsetFillEnabled=a,this._stateTracker.invalidatePolygonOffset())};b.prototype.setPolygonOffset=function(a,c){if(this._polygonOffset[0]!==a||this._polygonOffset[1]!==c)this._polygonOffset[0]=a,this._polygonOffset[1]=
c,this.gl.polygonOffset(a,c),this._stateTracker.invalidatePolygonOffset()};b.prototype.setCullFace=function(a){this._cullFace!==a&&(this.gl.cullFace(a),this._cullFace=a,this._stateTracker.invalidateCulling())};b.prototype.setFrontFace=function(a){this._frontFace!==a&&(this.gl.frontFace(a),this._frontFace=a,this._stateTracker.invalidateCulling())};b.prototype.setScissorTestEnabled=function(a){this._scissorTestEnabled!==a&&(!0===a?this.gl.enable(this.gl.SCISSOR_TEST):this.gl.disable(this.gl.SCISSOR_TEST),
this._scissorTestEnabled=a)};b.prototype.setScissorRect=function(a,c,d,b){if(this._scissorRect.x!==a||this._scissorRect.y!==c||this._scissorRect.width!==d||this._scissorRect.height!==b)this.gl.scissor(a,c,d,b),this._scissorRect.x=a,this._scissorRect.y=c,this._scissorRect.width=d,this._scissorRect.height=b};b.prototype.setDepthTestEnabled=function(a){this._depthTestEnabled!==a&&(!0===a?this.gl.enable(this.gl.DEPTH_TEST):this.gl.disable(this.gl.DEPTH_TEST),this._depthTestEnabled=a,this._stateTracker.invalidateDepthTest())};
b.prototype.setClearDepth=function(a){this._clearDepth!==a&&(this.gl.clearDepth(a),this._clearDepth=a)};b.prototype.setDepthFunction=function(a){this._depthFunction!==a&&(this.gl.depthFunc(a),this._depthFunction=a,this._stateTracker.invalidateDepthTest())};b.prototype.setDepthWriteEnabled=function(a){this._depthWriteEnabled!==a&&(this.gl.depthMask(a),this._depthWriteEnabled=a,this._stateTracker.invalidateDepthWrite())};b.prototype.setDepthRange=function(a,c){if(this._depthRange.zNear!==a||this._depthRange.zFar!==
c)this.gl.depthRange(a,c),this._depthRange.zNear=a,this._depthRange.zFar=c,this._stateTracker.invalidateDepthWrite()};b.prototype.setStencilTestEnabled=function(a){this._stencilTestEnabled!==a&&(!0===a?this.gl.enable(this.gl.STENCIL_TEST):this.gl.disable(this.gl.STENCIL_TEST),this._stencilTestEnabled=a,this._stateTracker.invalidateStencilTest())};b.prototype.setClearStencil=function(a){a!==this._clearStencil&&(this.gl.clearStencil(a),this._clearStencil=a)};b.prototype.setStencilFunction=function(a,
c,d){if(this._stencilFunction.func!==a||this._stencilFunction.ref!==c||this._stencilFunction.mask!==d)this.gl.stencilFunc(a,c,d),this._stencilFunction.face=1032,this._stencilFunction.func=a,this._stencilFunction.ref=c,this._stencilFunction.mask=d,this._stateTracker.invalidateStencilTest()};b.prototype.setStencilFunctionSeparate=function(a,c,d,b){if(this._stencilFunction.face!==a||this._stencilFunction.func!==c||this._stencilFunction.ref!==d||this._stencilFunction.mask!==b)this.gl.stencilFuncSeparate(a,
c,d,b),this._stencilFunction.face=a,this._stencilFunction.func=c,this._stencilFunction.ref=d,this._stencilFunction.mask=b,this._stateTracker.invalidateStencilTest()};b.prototype.setStencilWriteMask=function(a){this._stencilWriteMask!==a&&(this.gl.stencilMask(a),this._stencilWriteMask=a,this._stateTracker.invalidateStencilWrite())};b.prototype.setStencilOp=function(a,c,d){if(this._stencilOperation.fail!==a||this._stencilOperation.zFail!==c||this._stencilOperation.zPass!==d)this.gl.stencilOp(a,c,d),
this._stencilOperation.face=1032,this._stencilOperation.fail=a,this._stencilOperation.zFail=c,this._stencilOperation.zPass=d,this._stateTracker.invalidateStencilTest()};b.prototype.setStencilOpSeparate=function(a,c,d,b){if(this._stencilOperation.face!==a||this._stencilOperation.fail!==c||this._stencilOperation.zFail!==d||this._stencilOperation.zPass!==b)this.gl.stencilOpSeparate(a,c,d,b),this._stencilOperation.face=a,this._stencilOperation.face=a,this._stencilOperation.fail=c,this._stencilOperation.zFail=
d,this._stencilOperation.zPass=b,this._stateTracker.invalidateStencilTest()};b.prototype.setActiveTexture=function(a){var c=this._activeTextureUnit;0<=a&&a!==this._activeTextureUnit&&(this.gl.activeTexture(f.BASE_TEXTURE_UNIT+a),this._activeTextureUnit=a);return c};b.prototype.clear=function(a){a&&this.gl.clear(a)};b.prototype.clearSafe=function(a){a&&(a&16384&&this.setColorMask(!0,!0,!0,!0),a&256&&this.setDepthWriteEnabled(!0),a&1024&&this.setStencilWriteMask(255),this.gl.clear(a))};b.prototype.drawArrays=
function(a,c,d){this.gl.drawArrays(a,c,d)};b.prototype.drawElements=function(a,c,d,b){5123===d?this.gl.drawElements(a,c,d,b):5125===d&&this.gl.drawElements(a,c,d,b)};b.prototype.logIno=function(){};Object.defineProperty(b.prototype,"capabilities",{get:function(){return this._capabilities},enumerable:!0,configurable:!0});b.prototype.setViewport=function(a,c,b,e){var d=this._viewport;if(d.x!==a||d.y!==c||d.width!==b||d.height!==e)d.x=a,d.y=c,d.width=b,d.height=e,this.gl.viewport(a,c,b,e)};b.prototype.getViewport=
function(){return{x:this._viewport.x,y:this._viewport.y,width:this._viewport.width,height:this._viewport.height}};b.prototype.bindProgram=function(a){a?this._activeShaderProgram!==a&&(a.initialize(),this.gl.useProgram(a.glName),this._activeShaderProgram=a):(this.gl.useProgram(null),this._activeShaderProgram=null)};b.prototype.bindTexture=function(a,c){void 0===c&&(c=0);-1===b._MAX_TEXTURE_IMAGE_UNITS&&(b._MAX_TEXTURE_IMAGE_UNITS=this.gl.getParameter(this.gl.MAX_TEXTURE_IMAGE_UNITS));(c>=b._MAX_TEXTURE_IMAGE_UNITS||
0>c)&&console.error("Input texture unit is out of range of available units!");var d=this._textureUnitMap[c];this.setActiveTexture(c);null==a||null==a.glName?(null!=d&&(this.gl.bindTexture(d.descriptor.target,null),d.setBoundToUnit(c,!1)),this._textureUnitMap[c]=null):d&&d.id===a.id?a.applyChanges():(d&&d.setBoundToUnit(c,!1),this.gl.bindTexture(a.descriptor.target,a.glName),a.setBoundToUnit(c,!0),a.applyChanges(),this._textureUnitMap[c]=a)};b.prototype.bindFramebuffer=function(a){g.isNone(a)?(this.gl.bindFramebuffer(this.gl.FRAMEBUFFER,
null),this._activeFramebuffer=null):this._activeFramebuffer!==a&&(a.initialize()||this.gl.bindFramebuffer(this.gl.FRAMEBUFFER,a.glName),this._activeFramebuffer=a)};b.prototype.bindBuffer=function(a){a&&(34962===a.bufferType?this._activeVertexBuffer=b._bindBuffer(this.gl,a,a.bufferType,this._activeVertexBuffer):this._activeIndexBuffer=b._bindBuffer(this.gl,a,a.bufferType,this._activeIndexBuffer))};b.prototype.bindRenderbuffer=function(a){var c=this.gl;a||(c.bindRenderbuffer(c.RENDERBUFFER,null),this._activeRenderbuffer=
null);this._activeRenderbuffer!==a&&(c.bindRenderbuffer(c.RENDERBUFFER,a.glName),this._activeRenderbuffer=a)};b.prototype.unbindBuffer=function(a){34962===a?this._activeVertexBuffer=b._bindBuffer(this.gl,null,a,this._activeVertexBuffer):this._activeIndexBuffer=b._bindBuffer(this.gl,null,a,this._activeIndexBuffer)};b.prototype.bindVAO=function(a){a?this._activeVertexArrayObject&&this._activeVertexArrayObject.id===a.id||(a.bind(),this._activeVertexArrayObject=a):this._activeVertexArrayObject&&(this._activeVertexArrayObject.unbind(),
this._activeVertexArrayObject=null)};b.prototype.getBoundTexture=function(a){return this._textureUnitMap[a]};b.prototype.getBoundFramebufferObject=function(){return this._activeFramebuffer};b.prototype.getBoundVAO=function(){return this._activeVertexArrayObject};b.prototype.resetState=function(){this.bindProgram(null);this.bindVAO(null);this.bindFramebuffer(null);this.unbindBuffer(34962);this.unbindBuffer(34963);for(var a=0;a<this.parameters.maxTextureImageUnits;a++)this.bindTexture(null,a);this.setBlendingEnabled(!1);
this.setBlendFunction(1,0);this.setBlendEquation(32774);this.setBlendColor(0,0,0,0);this.setFaceCullingEnabled(!1);this.setCullFace(1029);this.setFrontFace(2305);this.setPolygonOffsetFillEnabled(!1);this.setPolygonOffset(0,0);this.setScissorTestEnabled(!1);this.setScissorRect(0,0,this.gl.canvas.width,this.gl.canvas.height);this.setDepthTestEnabled(!1);this.setDepthFunction(513);this.setDepthRange(0,1);this.setStencilTestEnabled(!1);this.setStencilFunction(519,0,0);this.setStencilOp(7680,7680,7680);
this.setClearColor(0,0,0,0);this.setClearDepth(1);this.setClearStencil(0);this.setColorMask(!0,!0,!0,!0);this.setStencilWriteMask(4294967295);this.setDepthWriteEnabled(!0);this.setViewport(0,0,this.gl.canvas.width,this.gl.canvas.height)};b.prototype.enforceState=function(){var a=this.gl,c=this.capabilities.vao;c&&c.bindVertexArray(null);for(var b=0;b<this.parameters.maxVertexAttributes;b++)a.disableVertexAttribArray(b);this._activeVertexBuffer?a.bindBuffer(this._activeVertexBuffer.bufferType,this._activeVertexBuffer.glName):
a.bindBuffer(34962,null);this._activeIndexBuffer?a.bindBuffer(this._activeIndexBuffer.bufferType,this._activeIndexBuffer.glName):a.bindBuffer(34963,null);if(c&&this._activeVertexArrayObject){if(c=this._activeVertexArrayObject)this._activeVertexArrayObject.unbind(),this._activeVertexArrayObject=null;this.bindVAO(c)}a.bindFramebuffer(a.FRAMEBUFFER,this._activeFramebuffer?this._activeFramebuffer.glName:null);a.useProgram(this._activeShaderProgram?this._activeShaderProgram.glName:null);a.blendColor(this._blendColorState.r,
this._blendColorState.g,this._blendColorState.b,this._blendColorState.a);a.bindRenderbuffer(a.RENDERBUFFER,this._activeRenderbuffer?this._activeRenderbuffer.glName:null);!0===this._blendEnabled?a.enable(this.gl.BLEND):a.disable(this.gl.BLEND);a.blendEquationSeparate(this._blendEquationState.mode,this._blendEquationState.modeAlpha);a.blendFuncSeparate(this._blendFunctionState.srcRGB,this._blendFunctionState.dstRGB,this._blendFunctionState.srcAlpha,this._blendFunctionState.dstAlpha);a.clearColor(this._clearColor.r,
this._clearColor.g,this._clearColor.b,this._clearColor.a);a.clearDepth(this._clearDepth);a.clearStencil(this._clearStencil);a.colorMask(this._colorMaskState.r,this._colorMaskState.g,this._colorMaskState.b,this._colorMaskState.a);a.cullFace(this._cullFace);a.depthFunc(this._depthFunction);a.depthRange(this._depthRange.zNear,this._depthRange.zFar);!0===this._depthTestEnabled?a.enable(a.DEPTH_TEST):a.disable(a.DEPTH_TEST);a.depthMask(this._depthWriteEnabled);a.frontFace(this._frontFace);a.lineWidth(1);
!0===this._polygonCullingEnabled?a.enable(a.CULL_FACE):a.disable(a.CULL_FACE);a.polygonOffset(this._polygonOffset[0],this._polygonOffset[1]);!0===this._polygonOffsetFillEnabled?a.enable(a.POLYGON_OFFSET_FILL):a.disable(a.POLYGON_OFFSET_FILL);a.scissor(this._scissorRect.x,this._scissorRect.y,this._scissorRect.width,this._scissorRect.height);!0===this._scissorTestEnabled?a.enable(a.SCISSOR_TEST):a.disable(a.SCISSOR_TEST);a.stencilFunc(this._stencilFunction.func,this._stencilFunction.ref,this._stencilFunction.mask);
a.stencilOpSeparate(this._stencilOperation.face,this._stencilOperation.fail,this._stencilOperation.zFail,this._stencilOperation.zPass);!0===this._stencilTestEnabled?a.enable(a.STENCIL_TEST):a.disable(a.STENCIL_TEST);a.stencilMask(this._stencilWriteMask);for(c=0;c<this.parameters.maxTextureImageUnits;c++)a.activeTexture(f.BASE_TEXTURE_UNIT+c),a.bindTexture(3553,null),(b=this._textureUnitMap[c])&&a.bindTexture(b.descriptor.target,b.glName);a.activeTexture(f.BASE_TEXTURE_UNIT+this._activeTextureUnit);
a.viewport(this._viewport.x,this._viewport.y,this._viewport.width,this._viewport.height)};b._bindBuffer=function(a,b,d,e){if(!b)return a.bindBuffer(d,null),null;if(e===b)return e;a.bindBuffer(d,b.glName);return b};b._MAX_TEXTURE_IMAGE_UNITS=-1;return b}()});