module.exports = {
  module: {
    rules: [
      {
        test: /\.scss$/,
        loader: "postcss-loader",
        options: {
          postcssOptions: {
            ident: "postcss",
            plugins: [require("tailwindcss"), require("autoprefixer")],
          },
        },
      },
    ],
  },
};
