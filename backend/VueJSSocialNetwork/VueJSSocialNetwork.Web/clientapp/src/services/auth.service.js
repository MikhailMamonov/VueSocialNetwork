"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.authService = void 0;
var axios_1 = require("axios");
var base_service_1 = require("./base.service");
var Rx_1 = require("rxjs/Rx");
var AuthService = /** @class */ (function (_super) {
    __extends(AuthService, _super);
    function AuthService() {
        return _super.call(this) || this;
    }
    Object.defineProperty(AuthService, "Instance", {
        get: function () {
            // Do you need arguments? Make it a regular method instead.
            return this.instance || (this.instance = new this());
        },
        enumerable: false,
        configurable: true
    });
    AuthService.prototype.login = function (credentials) {
        var _this = this;
        return Rx_1.Observable.fromPromise(axios_1.default.post(this.api + "/auth/login", credentials))
            .map(function (res) { return res.data.auth_token; })
            .catch(function (error) { return _this.handleError(error.response); });
    };
    AuthService.prototype.facebookLogin = function (accessToken) {
        var _this = this;
        return Rx_1.Observable.fromPromise(axios_1.default.post(this.api + "/externalauth/facebook", { accessToken: accessToken }))
            .map(function (res) { return res.data.auth_token; })
            .catch(function (error) { return _this.handleError(error.response); });
    };
    return AuthService;
}(base_service_1.BaseService));
// export a singleton instance in the global namespace
exports.authService = AuthService.Instance;
//# sourceMappingURL=auth.service.js.map