
var apiBase = "../api";

var draggable_modal = function (title, content, modalBg, kbIsActive) {
    $("body").on("mousedown touchstart", "#" + title, function (evt) {
        $("#" + content).addClass("draggable");
        var ptSt = evt.type === "touchstart" ? (evt.originalEvent.touches[0] || evt.originalEvent.changedTouches[0]) : evt;
        var offsetY = ptSt.clientY - $(".draggable").offset().top;
        var offsetX = ptSt.clientX - $(".draggable").offset().left;
        $("body").on("mousemove touchmove", function (e) {
            var ptMv = e.type === "touchmove" ? (e.originalEvent.touches[0] || e.originalEvent.changedTouches[0]) : e;
            $(".draggable").offset({
                top: ptMv.clientY - offsetY,
                left: ptMv.clientX - offsetX
            }).on("mouseup touchend touchcancel", function () {
                $("#" + content).removeClass("draggable");
                $("body").off("mousemove touchmove", false);
            });
            e.preventDefault();
        });
    }).on("mouseup touchend touchcancel", function () {
        $(".draggable").removeClass("draggable");
        $("body").off("mousemove touchmove", false);
    });

    if (kbIsActive) {
        $("body").on("keyup", function (e) {
            if (e.which === 27 || e.which === 13)
                $("#" + modalBg).hide();
        });
    }
};

var modal_open = function (content, top) {
    top = top || 0;

    $("#" + content + "_content").css({ top: "-50%", left: 0, opacity: 0 });
    $("#" + content + "_bg").fadeIn(430,
        function () {
            $("#" + content + "_content").animate({ top: top, opacity: 1 }, 500);
        });
},
    modal_close = function (content) {
        $("#" + content + "_content").animate({ top: "-50%", opacity: 0 },
            500,
            function () {
                $("#" + content + "_bg").fadeOut(430);
            });
    };



//***===My Message===***//
//  msg = array("type"=>"error", "title"=>"Error... . . !", "msg"=>"Invalid MFI Information !");
//  msg_opt.type, title, msg, autoOpen
function MyMessage() {
    //var msg = function () {
    this.init = function (msg_opt, title, msg, autoOpen) {
        if (typeof (msg_opt) === "undefined")
            return;
        if (msg_opt.constructor !== String || typeof msg_opt !== "string") {
            title = msg_opt["title"];
            msg = msg_opt["msg"];
            autoOpen = msg_opt["autoOpen"];
            msg_opt = msg_opt["type"];
        }
        var typeIsOk = (msg_opt && msg_opt.replace(/\s/g, "").length > 0);

        $("#msg-title-txt").removeClass("msg-title-txt").addClass("msg-title-txt msg-information");
        $("#msg-title-txt").text(title);

        if (typeIsOk)
            $("#msg-body-bg").removeClass().addClass("msg-body-bg msg-" + msg_opt);

        $("#msg-body-msg").html($.parseHTML(decodeURI(msg)));

        if (typeof (autoOpen) !== "undefined" && !autoOpen)
            return;

        this.open();
        return;
    };

    this.open = function () {
        var msgBg = $("#msg-modal-bg"),
            msgModal = $("#msg-content"),
            openSpeed = 480;

        msgBg.css({ visibility: "hidden", display: "block" });
        msgModal.css({ visibility: "hidden", display: "block", height: "auto" });

        var msgHeight = msgModal.height(),
            msgWidth = msgModal.width();

        msgBg.css({ visibility: "", display: "none" });
        msgModal.css({ visibility: "" });

        //var msgTop = ($(window).innerHeight() / 2 - msgHeight / 4) + 70,
        var msgTop = $(window).innerHeight() / 2 - 50,
            msgLeft = ($(window).innerWidth() - msgWidth) / 2 - 5;

        msgModal.css({ opacity: 0, height: 0, top: msgTop + "px", left: msgLeft + "px", display: "block" });
        try {
            msgBg.fadeIn(openSpeed / 4, function () {
                msgModal.animate({ opacity: 1, height: msgHeight, top: msgTop - msgHeight / 2 + "px" }, openSpeed, function () {
                    msgBg.css({ opacity: 1 });
                    msgModal.css({ display: "block", opacity: 1, height: "auto", overflow: "visible" });
                });
            });
        } catch (ex) {
            msgBg.animate({ opacity: 1 }, function () {
                msgModal.css({ display: "block", opacity: 1, height: msgHeight, overflow: "visible" });
            });
        }

        draggable_modal("msg-title", "msg-content", "msg-modal-bg");
        return;
    };

    this.close = function () {
        var msgBg = $("#msg-modal-bg"),
            msgModal = $("#msg-content"),
            closeSpeed = 430,
            msgTop = msgModal.offset().top + msgModal.outerHeight() / 2 - $(window).scrollTop();

        msgModal.animate({ opacity: 0, height: 0, top: msgTop + "px" }, closeSpeed, function () {
            msgModal.css({ opacity: 0, display: "none", height: 0 });
            msgBg.fadeOut(closeSpeed / 2);

            $("#msg-body-msg").html("");
        });
        return false;
    };

    this.closeBg = function () {
        var msgBg = $("#msg-modal-bg"),
            msgModal = $("#msg-content"),
            closeSpeed = 430;

        if (msgModal.css("display") === "none" || msgModal.css("display") !== "block") {
            msgModal.animate({ opacity: 0 }, closeSpeed, function () {
                msgModal.css({ opacity: 0, height: 0, display: "none" });
                msgBg.fadeOut(closeSpeed / 2);

                $("#msg-body-msg").html("");
            });
        }
        return false;
    };
}
var msg = new MyMessage();

//***===My Modal===***//
function MyModal() {
    //var modal = function () {
    this.init = function (title, contentId, autoOpen) {
        $("#modal-title-txt").text(title);
        if (contentId && $("#" + contentId))
            $("#modal-body-content").empty().append($("#" + contentId).html());

        if (typeof (autoOpen) !== "undefined" && !autoOpen)
            return false;

        this.open();
        return false;
    };

    this.open = function () {
        $("#modal-content").css({ top: "-350px", left: 0, opacity: 0 });
        $("#modal-bg").fadeIn(350, function () {
            $("#modal-content").animate({ top: "0", opacity: 1 }, 500);
        });

        draggable_modal("modal-title", "modal-content", "modal-bg");
        return false;
    };

    this.close = function () {
        $("#modal-content").animate({ top: "-350px", opacity: 0 }, 500, function () {
            $("#modal-bg").fadeOut(350);
        });
        return false;
    };
}
var modal = new MyModal();

