genrule(
    name = "api",
    srcs = glob([
        "**/*.cs",
        "**/*.csproj",
        "**/VERSION",
        "**/*.json",
        "**/dockerfile",
    ]),
    out = "image.tar",
    building_description = "building api service image",
    cmd = [
        "docker build -t mrss/api:latest -f services/api/dockerfile .",
        "docker save mrss/api:latest -o image.tar",
    ],
    data = [
        "AppConfig__Name",
        "mrss.api",
    ],
    deps = ["//lib/types"],
)