AMX_NATIVE_INFO PluginNatives[] =
{
	{"fileCreate", __file_create},			// fileCreate(path[])
	{"existFile", __file_exist},			// existFile(path[])
	{"removeFile", __file_remove},			// removeFile(path[])
	{"renameFile", __file_rename},			// renameFile(old[], new[])
	{"directoryCreate", __directory_create},// directoryCreate(path[])
	{"existDirectory", __directory_exist},	// existDirectory(path[])
	{"removeDirectory", __directory_remove},// removeDirectory(path[])
	{"renameDirectory", __directory_rename},// renameDirectory(old[], new[])
    {0, 0}
};