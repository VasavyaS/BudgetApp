"use strict";
(self["webpackChunkthebudgeteer"] = self["webpackChunkthebudgeteer"] || []).push([["category"],{

/***/ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/category-entry.js":
/*!************************************************************************************************************************************!*\
  !*** ../../../../../C # Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/category-entry.js ***!
  \************************************************************************************************************************************/
/***/ ((module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.a(module, async (__webpack_handle_async_dependencies__, __webpack_async_result__) => { try {
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var jquery_validation__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! jquery-validation */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/jquery-validation/dist/jquery.validate.js");
/* harmony import */ var jquery_validation__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(jquery_validation__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var jquery_validation_unobtrusive__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! jquery-validation-unobtrusive */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js");
/* harmony import */ var jquery_validation_unobtrusive__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(jquery_validation_unobtrusive__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _scss_bootstrap_imports_scss__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../scss/bootstrap-imports.scss */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/scss/bootstrap-imports.scss");
/* harmony import */ var datatables_net_bs5_css_dataTables_bootstrap5_min_css__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! datatables.net-bs5/css/dataTables.bootstrap5.min.css */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/datatables.net-bs5/css/dataTables.bootstrap5.min.css");
/* harmony import */ var country_select_js_build_css_countrySelect_min_css__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! country-select-js/build/css/countrySelect.min.css */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/country-select-js/build/css/countrySelect.min.css");
/* harmony import */ var bootstrap_icons_font_bootstrap_icons_css__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! bootstrap-icons/font/bootstrap-icons.css */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/bootstrap-icons/font/bootstrap-icons.css");
/* harmony import */ var bootstrap_datepicker_dist_css_bootstrap_datepicker3_min_css__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css");
/* harmony import */ var _scss_site_scss__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../scss/site.scss */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/scss/site.scss");
/* harmony import */ var _site_js__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./site.js */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/site.js");
/* harmony import */ var _category_js__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./category.js */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/category.js");
var __webpack_async_dependencies__ = __webpack_handle_async_dependencies__([_category_js__WEBPACK_IMPORTED_MODULE_9__]);
_category_js__WEBPACK_IMPORTED_MODULE_9__ = (__webpack_async_dependencies__.then ? (await __webpack_async_dependencies__)() : __webpack_async_dependencies__)[0];
﻿












__webpack_async_result__();
} catch(e) { __webpack_async_result__(e); } });

/***/ }),

/***/ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/category.js":
/*!******************************************************************************************************************************!*\
  !*** ../../../../../C # Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/category.js ***!
  \******************************************************************************************************************************/
/***/ ((module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.a(module, async (__webpack_handle_async_dependencies__, __webpack_async_result__) => { try {
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _asyncComponents__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./asyncComponents */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/asyncComponents.js");
/* harmony import */ var chart_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! chart.js */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/chart.js/dist/chart.js");
/* provided dependency */ var $ = __webpack_require__(/*! jquery */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/node_modules/jquery/dist/jquery.js");
﻿

chart_js__WEBPACK_IMPORTED_MODULE_1__.Chart.register(chart_js__WEBPACK_IMPORTED_MODULE_1__.DoughnutController, chart_js__WEBPACK_IMPORTED_MODULE_1__.ArcElement);

const chartDefaultsTask = (0,_asyncComponents__WEBPACK_IMPORTED_MODULE_0__.importChartDefaults)();

const currentDate = new Date();
const categoryId = document.getElementById('category_Id');

const categoryDashboard = await getCategoryDashboard(categoryId.value, currentDate, JSON.parse(categoryId.dataset.object));

const transactionsAPI = "https://localhost:7246/api/Transactions";
const addTransactionModal = $("#add-transaction-modal");
const updateTransactionModal = $("#updateTransaction-modal");
const transactionModalLabel = updateTransactionModal.find("#updateTransaction-label");
const transactionModalId = updateTransactionModal.find("#updateTransaction_id");
const transactionModalTitle = updateTransactionModal.find("#updateTransaction_title");
const transactionModalAmount = updateTransactionModal.find("#updateTransaction_amount");
const transactionModalCategoryId = updateTransactionModal.find("#updateTransaction_categoryId");
const transactionModalDateTime = updateTransactionModal.find("#updateTransaction_dateTime");
const transactionModalEvaluated = updateTransactionModal.find("#updateTransaction_evaluated");
const transactionModalEvaluatedIsHappy = updateTransactionModal.find("#updateTransaction_evaluatedIsHappy");
const transactionModalEvaluatedIsNecessary = updateTransactionModal.find("#updateTransaction_evaluatedIsNecessary");

const collapses = await (0,_asyncComponents__WEBPACK_IMPORTED_MODULE_0__.importBootstrapCollapses)();

const collapsesPromise = (0,_asyncComponents__WEBPACK_IMPORTED_MODULE_0__.importBootstrapCollapses)()
    .then(() => {
        $('.accordion-head').on('click', function (event) {
            if (!event.target.classList.contains('add-category-icon')) {
                let collapse = $(this).next();
                if (!collapse[0].classList.contains('collapsing')) {
                    collapse.collapse('toggle');
                    let caret = $('.accordion-caret', this)[0];
                    caret.classList.toggle('rotate');
                }               
            }
        });
    });

$('#add-transaction-form').on("submit", async function (event) {
    event.preventDefault();
    if ($(this).valid()) {
        addTransactionModal.modal('hide');
        const start = performance.now();
        await addTransaction(new FormData(this));
        const end = performance.now();
        console.log(`Execution time: ${end - start} ms`);
    }
});

$('#update-transaction-form').on("submit", async function (event) {
    event.preventDefault();
    if ($(this).valid()) {
        updateTransactionModal.modal('hide');
        await updateTransaction(new FormData(this));
    }
});

async function getCategoryDashboard(id, date, data) {
    try {
        const { default: CategoryDashboard } = await __webpack_require__.e(/*! import() | categoryDashboard */ "async-categoryDashboard").then(__webpack_require__.bind(__webpack_require__, /*! ./categoryDashboard */ "../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/categoryDashboard.js"));
        await chartDefaultsTask;

        return new CategoryDashboard(id, date, data);

    } catch (error) {
        console.error('Error loading category dashboard:', error);
        throw error;
    }
} 

__webpack_async_result__();
} catch(e) { __webpack_async_result__(e); } }, 1);

/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ __webpack_require__.O(0, ["styles-index~fiscalPlan~category","styles-fiscalPlan~category","vendors-index~fiscalPlan~category","vendors-category"], () => (__webpack_exec__("../../../../../C\u0000# Academy Repos/CodeReviews.MVC.Budget/MVC.Budget.K-MYR/MVC.Budget.K-MYR/ClientApp/src/js/category-entry.js")));
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);
//# sourceMappingURL=category.js.map