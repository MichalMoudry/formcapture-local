const { createWorker } = Tesseract;

async function recogSingleField(field, image, lang, contentType) {
    // Initialize variables
    const worker = createWorker();
    await worker.load();
    await worker.loadLanguage("eng");
    await worker.initialize("eng");
    var results = [];

    // Iterate for each input image
    const {
        data: { text }
    } = await worker.recognize("data:" + contentType + ";base64," + image,
    {
        rectangle: {
            top: field["xposition"],
            left: field["yposition"],
            width: field["width"],
            height: field["height"]
        }
    });
    // Push recognition result to array in this format:
    // [result] / [fieldID]
    results.push(text.replace(/\s/g, "") + "/" + field["id"]);

    // Finish recognition and return results
    await worker.terminate();
    return results;
}

async function recog(fields, images, lang, contentTypes) {
    // Initialize variables
    const worker = createWorker();
    await worker.load();
    await worker.loadLanguage(lang);
    await worker.initialize(lang);
    var results = [];

    // Iterate for each input image
    for (var i = 0; i < images.length; i++) {
        for (var x = 0; x < fields.length; x++) {
            const {
                data: { text }
            } = await worker.recognize("data:" + contentTypes[i] + ";base64," + images[i],
                {
                    rectangle: {
                        top: fields[x]["xposition"],
                        left: fields[x]["yposition"],
                        width: fields[x]["width"],
                        height: fields[x]["height"]
                    }
                });
            // Push recognition result to array in this format:
            // [result] / [fieldID] / [fileIndex]
            results.push(text.replace(/\s/g, "") + "/" + fields[x]["id"] + "/" + i);
        }
    }

    // Finish recognition and return results
    await worker.terminate();
    return results;
}

async function singleFileMultipleFieldsRecog(fields, image, lang, contentType) {
    // Initialize variables
    const worker = createWorker();
    await worker.load();
    await worker.loadLanguage(lang);
    await worker.initialize(lang);
    var results = [];

    // Iterate for each field
    for (var x = 0; x < fields.length; x++) {
        const {
            data: { text }
        } = await worker.recognize("data:" + contentType + ";base64," + image,
            {
                rectangle: {
                    top: fields[x]["xposition"],
                    left: fields[x]["yposition"],
                    width: fields[x]["width"],
                    height: fields[x]["height"]
                }
            });
        // Push recognition result to array in this format:
        // [result] / [fieldID]
        results.push(text.replace(/\s/g, "") + "/" + fields[x]["id"]);
    }

    // Finish recognition and return results
    await worker.terminate();
    return results;
}