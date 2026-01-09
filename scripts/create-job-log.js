const fs = require("fs");
const path = require("path");

const today = new Date().toISOString().split("T")[0];

const jobDir = path.join(__dirname, "..", "docs", "job-search");
const jobFile = path.join(jobDir, `${today}.md`);

if (!fs.existsSync(jobDir)) {
  fs.mkdirSync(jobDir, { recursive: true });
}

if (fs.existsSync(jobFile)) {
  console.log(`⚠️ Job log already exists for ${today}`);
  process.exit(0);
}

const content = `# Job Search — ${today}

**Done**
- 

**Next**
- 

**Waiting On**
- 
`;

fs.writeFileSync(jobFile, content, { encoding: "utf8" });

console.log(`🔒 Private job log created: docs/job-search/${today}.md`);
