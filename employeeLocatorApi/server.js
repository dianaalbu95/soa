var express = require('express'),
 app = express(),
 port = process.env.PORT || 3000,
 mongoose = require('mongoose'),
 EmployeeLocator = require('./api/models/employeeLocatorModel'),
 bodyParser = require('body-parser');

mongoose.Promise = global.Promise;
mongoose.connect('mongodb://localhost/EmployeeLocatorDb')

app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());

var routes = require('./api/routes/employeeLocator');
routes(app);

app.listen(port);

console.log('employeeLocator API server started on: ' + port);