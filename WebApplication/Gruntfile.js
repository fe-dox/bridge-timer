const fs = require('fs');

module.exports = function (grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        clean: {
            options: {
                force: true
            },
            default: ["../Utils/StyleSheet.cs", "CssOptions/*.css", "CssOptions/*.css.map"]
        },
        sass: {
            options: {
                "style": "compressed",
                "no-source-map": true,
            },
            dist: {
                files: {
                    'CssOptions/Default.css': 'CssOptions/Default.scss',
                    'CssOptions/HighContrast.css': 'CssOptions/HighContrast.scss',
                    'CssOptions/WhiteOnBlack.css': 'CssOptions/WhiteOnBlack.scss',
                    'CssOptions/Crazy.css': 'CssOptions/Crazy.scss',
                }
            },
        },

        template: {
            generateStyleSheetCs: {
                options: {
                    data: {
                        stylesheets: [
                            {
                                name: "Default",
                                content: fs.readFileSync("CssOptions/Default.css")
                            },
                            {
                                name: "HighContrast",
                                content: fs.readFileSync("CssOptions/HighContrast.css")
                            },
                            {
                                name: "WhiteOnBlack",
                                content: fs.readFileSync("CssOptions/WhiteOnBlack.css")
                            },
                            {
                                name: "Crazy",
                                content: fs.readFileSync("CssOptions/Crazy.css")
                            },
                        ]
                    }
                },
                files: {
                    "../Utils/StyleSheet.cs": "CssOptions/StyleSheet.cs.ejs"
                }
            }
        }

    });


    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-template');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.registerTask('default', ['clean', 'sass', 'template']);
}