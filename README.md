# Data Point Cloud Cluster

## Getting started

The use of the **–recursive** flag is necessary to retrieve also all submodules.
```
git clone --recursive https://github.com/chrissoe/DataPointCloudCluster.git
```
If this is the first time you clone this project to your machine run the following command from within **the project folder**
```
mklink /j .\Assets\HoloToolkit .\MixedRealityToolkit-Unity\Assets\HoloToolkit
```

## Usage

This project will visualize data coming from a JSON file in a point cloud cluster. Depending which key is flagged as priority, the important or unusual values will stand out as they will be moved more far away from the middle of the cluster. There is also a threshold to display the most important values in red. The "SampleJSON" json file in the resources folder of the project is an example of how to utilize JSON formatted data with the cluster.

Find an example visualization below:

![PointCloud Visualization](https://i.imgur.com/knYWv1K.png)
