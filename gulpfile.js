var gulp = require('gulp'),
    watch = require('gulp-watch');
    spawn = require('child_process').spawn;

var active_process = null;
var runKestrel = function() {
  if (active_process != null) {
    active_process.kill('SIGHUP');
  }
  active_process = spawn("k", ["kestrel"]);//spawn("/bin/bash", ["--login", "-c", "\"/Users/callumj/.kre/packages/KRE-Mono.1.0.0-beta1/bin/k kestrel\""]);
  active_process.stdout.on('data', function(buf) {
    console.log('[Kestrel] %s', String(buf).trim());
  });
  active_process.stderr.on('data', function(buf) {
    console.log('[Kestrel] %s', String(buf).trim());
  });
}

gulp.task('watch', function () {
  runKestrel();
  watch('**/*.cs', function () {
    runKestrel();
  });
});

gulp.task('default', ['watch']);