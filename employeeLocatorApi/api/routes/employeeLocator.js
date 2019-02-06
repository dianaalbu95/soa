'use strict';

module.exports = function(app){
    var employeeLocator = require('../controllers/employeeLocatorController');

    app.route('/employeeLocator')
     .get(employeeLocator.list_employees)
     .post(employeeLocator.add_employee);

    app.route('/employeeLocator/:employeeId')
     .get(employeeLocator.get_employee)
     .put(employeeLocator.update_employee)
     .delete(employeeLocator.delete_employee);
};
