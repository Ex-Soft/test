const env = process.env;

console.log("TEST_ENV_VARIABLE1=%s", env.TEST_ENV_VARIABLE1);
console.log("TEST_ENV_VARIABLE2=%s", env.TEST_ENV_VARIABLE2);
console.log("TEST_ENV_VARIABLE3=%s", env.TEST_ENV_VARIABLE3);

console.log("TEST_DEV_ENV_VARIABLE=%s", env.TEST_DEV_ENV_VARIABLE);