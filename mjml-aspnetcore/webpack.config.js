const path = require('path');
const webpack = require('webpack');

module.exports = {
    stats: {
        modules: false
    },
    entry: {
        'renderer': './scripts/renderer.js',
    },
    resolve: {
        extensions: ['.js'],
        alias: {
            'mimer': path.resolve(__dirname, 'lib/mimer/mimer.js'),
            'uglify-js': path.resolve(__dirname, 'mocks/uglify-js'),
        },
    },
    output: {
        path: path.join(__dirname, 'dist'),
        filename: '[name].js',
        libraryTarget: 'commonjs2',
    },
    mode: 'development',
    // mode: 'production',
    target: 'node',
    module: {
        rules: [{
            test: /\.js$/,
            exclude: /node_modules/,
            loader: "babel-loader"
        }, 
        {
            test: /\.js$/,
            include: path.resolve(__dirname, 'node_modules', 'datauri'),
            use: [require.resolve('shebang-loader')]
        }],
        exprContextRegExp: /$^/,
        exprContextCritical: false,
    }
};