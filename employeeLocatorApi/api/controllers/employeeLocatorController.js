'use strict';

var mongoose = require('mongoose'),
 EmployeeLocator = mongoose.model('EmployeeLocator');

exports.list_employees = function(req, res){
    EmployeeLocator.find({}, function(err, employee){
        if(err)
         res.send(err);
        res.json(employee);
    });
};

exports.add_employee = function(req, res){
    var new_employee = new EmployeeLocator(req.body);
    new_employee.save(function(err, employee){
        if(err)
         res.send(err);
        res.json(employee)
    });
};

exports.get_employee = function(req, res){
    EmployeeLocator.findById(req.params.employeeId, function(err, employee){
        if(err)
         res.send(err);
        res.json(employee);
    });
};

exports.update_employee = function(req, res){
    EmployeeLocator.findOneAndUpdate({_id: req.params.employeeId}, req.body, {new: true}, function(err, employee){
        if(err)
         res.send(err);
        res.json(employee);
    });
};

exports.delete_employee = function(req, res){
    EmployeeLocator.remove({
        _id : req.params.employeeId
    }, function(err, employee){
        if(err)
         res.send(err);
        res.json({message: 'Employee deleted'});
    });
};