# subinclude("///pleasings//docker")

# docker_image(
#     name = "service-api",
#     srcs = glob(["**"]),
#     dockerfile = "dockerfile",
# )

genrule(
    name = "service-api",
    srcs = glob(["**"]),
    out = "image.tar",
    building_description = "building api service image",
    cmd = [
        "docker build -t mrss/api:latest -f service-api/dockerfile .",
        "docker save mrss/api:latest -o image.tar",
    ],
    data = [
        "AppConfig__Name",
        "mrss.api",
    ],
    deps = ["//lib-types"],
)