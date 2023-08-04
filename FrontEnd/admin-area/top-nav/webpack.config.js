const { merge } = require("webpack-merge");
const singleSpaDefaults = require("webpack-config-single-spa-react");

module.exports = (webpackConfigEnv, argv) => {
  const defaultConfig = singleSpaDefaults({
    orgName: "tapp",
    projectName: "admin-area-top-nav",
    webpackConfigEnv,
    argv,
  });

  const externals = [
    "@tapp/shared-styleguide"
  ];

  return merge(defaultConfig, {
    externals,
    output: {
      hashFunction: "sha256",
    },
  });
};
