'use strict';
var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var EmployeeSchema = new Schema({
    firstName: {
        type: String,
        required: 'Enter your first name'
    },
    lastName: {
        type: String,
        required: 'Enter your last name'
    },
    city: {
        type: String,
        enum: ['Cluj-Napoca', 'Bucuresti', 'Timisoara']
    },
    building:{
        type: String,
        required: 'Enter your office building'
    },
    floor:{
        type: String,
        required: 'Enter the floor'
    }
});

module.exports = mongoose.model('EmployeeLocator', EmployeeSchema);