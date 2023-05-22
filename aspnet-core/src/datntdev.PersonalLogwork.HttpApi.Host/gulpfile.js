import gulp from 'gulp';
import dartSass from 'sass';
import gulpSass from 'gulp-sass';
import rename from 'gulp-rename';
const sass = gulpSass(dartSass);

gulp.task('sass', function () {
    return gulp.src('Themes/Default/Styles/style.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('wwwroot/styles/themes/default'));
});