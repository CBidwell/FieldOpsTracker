const { execSync } = require("child_process");
const path = require("path");

function run(scriptName) {
  const scriptPath = path.join(__dirname, scriptName);
  try {
    execSync(`node "${scriptPath}"`, { stdio: "inherit" });
  } catch (err) {
    console.error(`❌ Failed running ${scriptName}`);
  }
}

run("create-standup.js");
run("create-job-log.js");