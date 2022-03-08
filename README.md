# Unity Groups
Unity3d groups allowing for the grouping and categorization of game objects.

This project is inspired on the [presentation](https://youtu.be/raQ3iHhE_Kk?t=1673) by [Ryan Hipple](https://twitter.com/roboryantron).

Feedback is welcome.

## Plug and Play
1. Open "Package Manager"
2. Choose "Add package from git URL..."
3. Use the HTTPS URL of this repository:
   `https://github.com/yanicksenn/unity-groups.git#1.0.0`
4. Click "Add"

## Usage
- [Default Group](#user-content-default-group)
- [Default Group Container](#user-content-default-group-container)
- [Custom Group](#user-content-default-custom-container)
- [Custom Group Container](#user-content-custom-group-container)

### Default Group

Default groups can be created through the asset menu > Create > Groups > ... .

![Asset menu](./Documentation/asset-menu.png)

### Default Group Container

Deafult groups can be assgined to `GameObject`s through the component `DefaultGroupContainer`.

![Context menu asset](./Documentation/default-group-container.png)

As soon the `OnEnable()` of this component is called the `GameObject` is added to all groups specified in the container.

It is possible to iterate through the groups the 

