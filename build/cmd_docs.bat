::����Ҫ���ذ�װ docfx���ߣ���ַ��https://github.com/dotnet/docfx/releases/download/v2.36.2/docfx.zip
::���غ��ѹ������·����ӵ��������� Path ��
docfx init -q -o ../docs
docfx metadata ../osharp-ns20.sln
move _api ../docs/_api
echo ���ֶ����� _api �� api ���ļ�����
pause
docfx ../docs/docfx.json