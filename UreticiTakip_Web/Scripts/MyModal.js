/**
 * Bootstrap modal helper class.
 * Just create new instance and work with window like object.
 *
 * <pre>
 * $('#link').click(function (e) {
 *     e.preventDefault();
 *
 *     modalWindow = new Modal({
 *         id: "MyWindow",
 *         header: "Login Please",
 *         footerCloseButton: "Close",
 *     });
 *
 *     modalWindow.getBody().load('/user/login', function () {
 *         modalWindow.show();
 *         modalWindow.getBody().find('form').myFormCalBack();
 *     });
 * });
 * </pre>
 *
 * @param {Object} [options] Options list.
 * @param {String|Boolean} [options.header = false] Header text. Default false - do not show header block.
 * @param {Boolean} [options.closeButton = true] Show or not header close button. It makes sense only if the options.header is logical true.
 * @param {Boolean} [options.footer = false] Show or not footer block. Default false;
 * @param {String|Boolean} [options.footerCloseButton = false] Footer close button text. Default false - do not show footer close button.
 * @param {String} [options.id = "myModal"] Modal container id attribute;
 *
 * @constructor
 */
var Modal = function (options) {
    var $this = this;

    options = options ? options : {};
    $this.options = {};
    $this.options.header = options.header !== undefined ? options.header : false;
    $this.options.footer = options.footer !== undefined ? options.footer : false;
    $this.options.closeButton = options.closeButton !== undefined ? options.closeButton : true;
    $this.options.footerCloseButton = options.footerCloseButton !== undefined ? options.footerCloseButton : false;
    $this.options.id = options.id !== undefined ? options.id : "myModal";
    $this.options.action = options.action !== undefined ? options.action : "";
    $this.options.controller = options.controller !== undefined ? options.controller : "";
    $this.options.param = options.param !== undefined ? options.param : "";

    /**
     * Append modal window html to body
     */
    $this.createModal = function () {
        $('body').append('<div id="' + $this.options.id + '" class="modal fade"></div>');
        $($this.selector).append('<div class="modal-dialog modal-lg"><div class="modal-content"></div></div>');
        var win = $('.modal-content', $this.selector);
        if ($this.options.header) {
            win.append('<div class="modal-header"><h4 class="modal-title"></h4></div>');
            if ($this.options.closeButton) {
                win.find('.modal-header').append('<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>');
            }
        }

        win.append('<div class="modal-body"></div>');

        if ($this.options.footer) {
            win.append('<div class="modal-footer"></div>');
            if ($this.options.footerCloseButton) {
                win.find('.modal-footer').append('<a data-dismiss="modal" href="#" class="btn btn-default">' + $this.options.footerCloseButton + '</a>');
            }
        }
    };

    /**
     * Set header text. It makes sense only if the options.header is logical true.
     * @param {String} html New header text.
     */
    $this.setHeader = function (html) {
        $this.window.find('.modal-title').html(html);
    };

    /**
     * Set body HTML.
     * @param {String} html New body HTML
     */

    $this.setBody = function (link) {
        $('.modal-body').load(link);
    };

    $this.setBody2 = function () {
        $('.modal-body').load("/" + $this.options.controller + "/" + $this.options.action + "?param=" + $this.options.param);
    };

    /**
     * Set footer HTML.
     * @param {String} html New footer HTML
     */
    $this.setFooter = function (html) {
        $this.window.find('.modal-footer').html(html);
    };

    /**
     * Return window body element.
     * @returns {jQuery} The body element
     */
    $this.getBody = function () {
        return $this.window.find('.modal-body');
    };

    /**
     * Show modal window
     */
    $this.show = function () {
        $this.window.modal('show');
    };

    $this.hide = function () {
        $this.window.modal('hide');
    }

    /**
     * Hide modal window
     */
    $this.hide = function () {
        $this.window.modal('hide');
    };

    /**
     * Toggle modal window
     */
    $this.toggle = function () {
        $this.window.modal('toggle');
    };

    $this.selector = "#" + $this.options.id;
    if (!$($this.selector).length) {
        $this.createModal();
    }
    $this.window = $($this.selector);
    $this.setHeader($this.options.header);
    $this.setBody2();
};

