const { merge } = require("webpack-merge");
const singleSpaDefaults = require("webpack-config-single-spa-react");
const webpack = require("webpack");

module.exports = (webpackConfigEnv, argv) => {
  let envFile = ".env.production";
  if (webpackConfigEnv.stage) {
    envFile = `.env.${webpackConfigEnv.stage}`;
  }

  const dotenv = require("dotenv").config({ path: `${__dirname}/${envFile}`});

  const defaultConfig = singleSpaDefaults({
    orgName: "tapp",
    projectName: "shared-config",
    webpackConfigEnv,
    argv,
  });

  const plugin = new webpack.DefinePlugin({
    "process.env": JSON.stringify(dotenv.parsed),
  });
  defaultConfig.plugins.push(plugin);

  return merge(defaultConfig, {
    output: {
      hashFunction: "sha256",
    },
  });
};
