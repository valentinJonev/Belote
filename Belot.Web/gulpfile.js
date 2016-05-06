/// <binding BeforeBuild='build' Clean='clean' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var gulpif = require('gulp-if');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require('gulp-rimraf');
var rename = require('gulp-rename');
var gulpNgConfig = require('gulp-ng-config');
var htmlreplace = require('gulp-html-replace');
var manifest = require('gulp-manifest');
var typescript = require('gulp-typescript');
var sourcemaps = require('gulp-sourcemaps');

function buildConfig() {
    var config, i = process.argv.indexOf("--mode");
    if (i > -1) {
        config = process.argv[i + 1];
    }

    return config;
}

gulp.task('clean', function () {
    return gulp.src('wwwroot/scripts/app/*', { read: false })
               .pipe(rimraf());
});

gulp.task('configure', function () {
    gulp.src('config.json')
        .pipe(gulpNgConfig('belot-web-service-url', { environment: buildConfig() }))
        .pipe(rename('serviceUrlConstants.js'))
        .pipe(gulp.dest('wwwroot/scripts/app'));

    return gulp.src('wwwroot/index.html')
        .pipe(gulpif(buildConfig() !== 'Debug',
            htmlreplace({
                'baseHref': '<base href="/Belot/">'
            }, { keepBlockTags: true }),
            htmlreplace({
                'baseHref': '<base href="/">'
            }, { keepBlockTags: true })))
        .pipe(gulp.dest('wwwroot/'));
});

gulp.task('build', ['clean', 'configure'], function () {
    return gulp.src('app_ts/**/*.ts')
        .pipe(sourcemaps.init())
        .pipe(typescript({
            sortOutput: false,
            sourceMap: true,
            target: 'ES5'
        }))
        .pipe(concat('app.min.js'))
        .pipe(gulpif(buildConfig() !== 'Debug', uglify()))
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/scripts/app/'))
});

gulp.task('pre-publish', function () {
    return gulp.src('C:/inetpub/wwwroot/Belot/*', { read: false })
               .pipe(rimraf({ force: true }));
});

gulp.task('publish', ['pre-publish'], function () {
    return gulp.src(['wwwroot/**/*', '!wwwroot/{bin,bin/**}'])
        .pipe(gulp.dest('C:/inetpub/wwwroot/BelotWeb'));
});