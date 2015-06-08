define(function () {
    'use strict';
    var Course;
    Course = (function () {

        var sortBy = function (type, array) {
            array.sort(function (first, second) {
                return second[type] - first[type];
            });
        }


        function Course(courseName, formula) {
            this.courseName = courseName;
            this._formula = formula;
            this._students = [];
        }
        
        Course.prototype.addStudent = function (student) {
            this._students.push(student);
            return this;
        };

        Course.prototype.calculateResults = function () {

            for (var i = 0, len = this._students.length; i < len; i++) {
                this._students[i].courseScore = this._formula(this._students[i]);
            }
        }

        Course.prototype.getTopStudentsByExam = function (number) {

            number = number || this._students.length;

            sortBy('exam', this._students);
            return this._students.slice(0, number);
        };

        Course.prototype.getTopStudentsByTotalScore = function (number) {

            number = number || this._students.length;

            sortBy('courseScore', this._students);
            return this._students.slice(0, number);
        };

        return Course;
    })();

    return Course;
});