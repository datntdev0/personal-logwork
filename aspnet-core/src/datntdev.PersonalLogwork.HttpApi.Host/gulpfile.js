import gulp from 'gulp';
import dartSass from 'sass';
import gulpSass from 'gulp-sass';
import rename from 'gulp-rename';
import uglify from 'gulp-uglify';
import concat from 'gulp-concat';
const sass = gulpSass(dartSass);

gulp.task('buildStyles', function () {
    return gulp.src('Themes/Default/Styles/style.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('wwwroot/styles/themes/default'));
});

gulp.task('buildScripts', function () {
    const scripts = [
        'node_modules/jquery/dist/jquery.js',
        'node_modules/@abp/core/src/abp.js'
    ];

    return gulp.src(scripts)
        .pipe(uglify())
        .pipe(concat('scripts.js'))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('wwwroot/scripts'));
})

gulp.task('build', gulp.parallel('buildStyles', 'buildScripts'))