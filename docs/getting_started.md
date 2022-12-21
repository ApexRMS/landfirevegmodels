---
layout: default
title: Getting started
---

# Getting started with **landfirevegmodels**

## Installing required packages

1. Download and install [SyncroSim version 2.2.19](https://syncrosim.com/download/){:target="_blank"} or higher and follow the installation prompts.

2. Open SyncroSim and select **File > Packages… > Install…**. Then, mark the check-boxes beside the **stsim** and **landfirevegmodels** packages and click OK.

3. You may need to update the **stsim** package to version 3.2.21 or later. To do so, select **File > Packages > Update...**, mark the check-box beside the **stsim** package and click **OK**.

<br>

## Creating a new **landfirevegmodels** Library 

1. In SyncroSim, select **File > New...**. 

2. Select the **landfirevegmodels** base package and choose either the **Reference Models** or **Example Models** template library.

3. Enter a **Filename** or keep the default, select a **Folder** for your new library, and click **OK**. A download window should appear and your library will be created from an online template.

<br>

## Configuring the Library

1. Right-click on the Project datafeed (*i.e.*, **Definitions**) and select **Properties**. Navigate to the **Landfire** tab, where you can specify details about the quantity, type, and composition of the vegetation for your model.

<img align="middle" style="padding: 1px" width="500" src="assets/images/project-landfire-tab-opened.png">

2. Right-click on the Scenario datafeed (*i.e.*, the Scenario name) and select **Properties**. Navigate to the **Landfire** tab, where you can provide further information about the model, including detailed **Succession Class Descriptions** and **Succession Class Mapping Rules**.

<img align="middle" style="padding: 1px" width="500" src="assets/images/scenario-landfire-tab-opened.png">

<br>

## Learn more

For documentation on the SyncroSim user interface see the SyncroSim [Getting Started](http://docs.syncrosim.com/getting_started/quickstart.html){:target="_blank"} page.

The *landfirevegmodels* package is a wrapper for the ST-Sim package for SyncroSim. For more information on ST-Sim see the [documentation](http://docs.stsim.net/){:target="_blank"} page.
