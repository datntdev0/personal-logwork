import gulp from 'gulp';
import dartSass from 'sass';
import gulpSass from 'gulp-sass';
import rename from 'gulp-rename';
import uglify from 'gulp-uglify';
import concat from 'gulp-concat';
import clean from 'gulp-clean';

const sass = gulpSass(dartSass);

const fontFiles = [
    'node_modules/@fortawesome/fontawesome-free/webfonts/*',
];
const styles = [
    'node_modules/@fortawesome/fontawesome-free/css/all.min.css',
];
function copyStylesTask() {
    return gulp.src(styles)
        .pipe(concat('fonts.css'))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('wwwroot/styles'))
}
function copyFontsTask() {
    return gulp.src(fontFiles)
        .pipe(gulp.dest('wwwroot/webfonts'));
}

gulp.task('buildFonts', gulp.parallel(copyStylesTask, copyFontsTask));

gulp.task('buildStyles', function () {
    return gulp.src('Themes/Default/Styles/style.scss')
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('wwwroot/styles/themes/default'));
});

gulp.task('buildScripts', function () {
    const scripts = [
        'node_modules/jquery/dist/jquery.js',
        'node_modules/@abp/core/src/abp.js',
        'node_modules/bootstrap/dist/js/bootstrap.js'
    ];

    return gulp.src(scripts)
        .pipe(uglify())
        .pipe(concat('scripts.js'))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('wwwroot/scripts'));
});

gulp.task('clean', function () {
    const folders = ['wwwroot/styles', 'wwwroot/scripts', 'wwwroot/webfonts'];
    return gulp.src(folders).pipe(clean({ force: true, read: false, allowEmpty: true }));
});

gulp.task('build', gulp.parallel('buildFonts', 'buildStyles', 'buildScripts'))