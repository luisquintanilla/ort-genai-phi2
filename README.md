## Prerequisites

It's recommended you open this repo using devcontainers. Otherwise, you'll need the following:

- Python 3.10
- .NET SDK 6.0
- CUDA

## Setup

### Get the model

1. Install ONNX Runtime GenAI Library

    ```bash
    pip install onnxruntime-genai
    ```

1. Install model dependencies

    ```bash
    pip install numpy transformers[torch] onnx onnxruntime huggingface_hub[cli]
    ```

1. Set HuggingFace token environment variable in *.devcontainer.json* file

    ```json
    "containerEnv": {
        "HUGGINGFACE_TOKEN": "REPLACE-WITH-YOUR-TOKEN"
    }
    ```

1. Log into HuggingFace. For more details, see the [documentation](https://huggingface.co/docs/huggingface_hub/main/en/guides/cli#huggingface-cli-login)

    ```bash
    huggingface-cli login --token $HUGGINGFACE_TOKEN
    ```

1. Create a new directory called *phi2-int4-cuda* inside your *ORTGenAIPhi* directory.

    ```bash
    mkdir -p ./ORTGenAIPhi/phi2-int4-cuda
    ```

1. Convert the model

    ```bash
    python3 -m onnxruntime_genai.models.builder -m microsoft/phi-2 -e cuda -p int4 -o ./ORTGenAIPhi/phi2-int4-cuda
    ```

### Build and run the app

```bash
dotnet build
dotnet run
```

## Additional Resources

- [Phi-2 ORT Gen AI Sample](https://github.com/microsoft/onnxruntime-genai/tree/main/examples/csharp/HelloPhi2)