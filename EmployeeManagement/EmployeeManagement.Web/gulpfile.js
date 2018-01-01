/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');

var node = './node_modules/';
var ng = [node + 'angular/*.js', '!' + node + 'angular/*.min.js'];
var ngRoute = [node + 'angular-route/*.js', '!' + node + '/angular-route/*.min.js'];
var ignore = ['!' + node + '/angular/index.js', '!' + node + '/angular-route/index.js'];
var allSrcFiles = ng.concat(ngRoute).concat(ignore);

var config = {
    src: allSrcFiles
}

gulp.task('clean', function () {
    return del('content/scripts/libs/all.min.js')
});

gulp.task('scripts', function () {
    return gulp.src(config.src)
        .pipe(gulp.dest('./content/scripts/libs/'));
});

gulp.task('watch', function () {
    return gulp.watch(config.src, ['scripts']);
});

gulp.task('default', ['scripts'], function () {
    // place code for your default task here
});

