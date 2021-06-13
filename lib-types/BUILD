genrule(
    name = "lib-types",
    srcs = glob([
        "**/*.cs",
        "**/*.csproj",
    ]),
    binary = False,
    cmd = "(rm -rf out || true) && mkdir out && cp -R ./lib-types/*.cs ./lib-types/*.csproj out",
    output_dirs = ["out"],
    visibility = ["PUBLIC"],
)